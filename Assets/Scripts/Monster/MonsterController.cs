using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamageable
{
	[Header("Components")]
	[SerializeField] BoxCollider2D attackCollider;
	[SerializeField] Animator animator;

	[Header("Specs")]
	[SerializeField] float moveSpeed;
	[SerializeField] float health;
	[SerializeField] float damage;
	public float Damage { get { return damage; } }

	private void OnEnable()
	{
		Manager.Game.OnArrivalStateChanged += UpdatePlayerTurn;
		Manager.Turn.OnTurnChanged += UpdateTurnChanged;
	}

	private void OnDisable()
	{
		Manager.Game.OnArrivalStateChanged -= UpdatePlayerTurn;
		Manager.Turn.OnTurnChanged -= UpdateTurnChanged;
	}

	private void UpdatePlayerTurn()
	{
		StartCoroutine(PlayerTurn());
	}

	private void UpdateTurnChanged(TurnManager.Turn turn)
	{
		if (turn == TurnManager.Turn.Monster)
		{
			StartCoroutine(MoveToTargetAndAttack());
		}
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		animator.SetTrigger("TakeHit");

		if (health <= 0)
		{
			Manager.Game.OnMonsterDeath?.Invoke();
			animator.SetBool("Die", true);
			Destroy(gameObject);
		}
	}

	private IEnumerator PlayerTurn()
	{
		yield return new WaitForSeconds(1f);
		Manager.Turn.CurrentTurn = TurnManager.Turn.Player;
	}

	private IEnumerator MoveToTargetAndAttack()
	{
		animator.SetBool("Move", true);
		yield return MoveTo(Manager.Game.PlayerTargetX);
		animator.SetBool("Move", false);
		animator.SetTrigger("Attack");
		attackCollider.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		attackCollider.gameObject.SetActive(false);
		animator.SetBool("Move", true);
		yield return MoveTo(Manager.Game.MonsterOriginalX);
		animator.SetBool("Move", false);

		Manager.Turn.CurrentTurn = TurnManager.Turn.Player;
	}

	private IEnumerator MoveTo(float targetX)
	{
		Vector3 currentPosition = transform.position;
		while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
		{
			float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime);
			transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);
			yield return null;
		}
	}
}
