using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamageable
{
	[Header("Components")]
	[SerializeField] BoxCollider2D attackCollider;
	[SerializeField] Animator animator;
	[SerializeField] MonsterModel monsterModel;

	private void Start()
	{
		UpdateHealthAndDamage();
	}

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

	private void UpdateHealthAndDamage()
	{
		monsterModel.MaxHealth += Manager.Game.DayCount * 5;
		monsterModel.CurrentHealth += Manager.Game.DayCount * 5;
		monsterModel.Damage += Manager.Game.DayCount * 2;
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
		monsterModel.CurrentHealth -= damage;
		animator.SetTrigger("TakeHit");

		Vector3 worldPosition = transform.position + Vector3.up * 1f;
		Manager.UI.ShowDamageText(worldPosition, damage);

		if (monsterModel.CurrentHealth <= 0)
		{
			Manager.Game.OnMonsterDeath?.Invoke();
			animator.SetBool("Die", true);
			StartCoroutine(DieCoroutine());
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
		yield return new WaitForSeconds(0.2f);
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
			float newX = Mathf.MoveTowards(transform.position.x, targetX, monsterModel.MoveSpeed * Time.deltaTime);
			transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);
			yield return null;
		}
	}

	private IEnumerator DieCoroutine()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
