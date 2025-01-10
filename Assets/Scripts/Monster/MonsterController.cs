using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamageable
{
	[Header("Components")]
	[SerializeField] BoxCollider2D attackCollider;
	[SerializeField] Animator animator;

	[Header("Specs")]
	[SerializeField] LayerMask layer;
	[SerializeField] float moveSpeed;
	[SerializeField] float health;
	[SerializeField] float damage;

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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (layer.Contain(collision.gameObject.layer))
		{
			IDamageable damageable = collision.GetComponent<IDamageable>();
			if (damageable != null)
			{
				damageable.TakeDamage(damage);
			}
		}
	}

	public void TriggerAttackCollider(int state)
	{
		bool isActive = (state == 1);
		attackCollider.gameObject.SetActive(isActive);
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
			animator.SetBool("Die", true);
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
		yield return new WaitForSeconds(1f);
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
