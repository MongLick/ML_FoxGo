using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
	[Header("Components")]
	[SerializeField] BoxCollider2D attackCollider;
	[SerializeField] GameModel gameModel;
	[SerializeField] Animator animator;

	[Header("Specs")]
	[SerializeField] float moveSpeed;

	private void OnEnable()
	{
		Manager.Game.OnArrivalStateChanged += UpdateAnimatorState;
		Manager.Turn.OnTurnChanged += UpdateTurnChanged;
	}

	private void OnDisable()
	{
		Manager.Game.OnArrivalStateChanged -= UpdateAnimatorState;
		Manager.Turn.OnTurnChanged -= UpdateTurnChanged;
	}

	public void TriggerAttackCollider(int state)
	{
		bool isActive = (state == 1);
		attackCollider.gameObject.SetActive(isActive);
	}

	private void UpdateTurnChanged(TurnManager.Turn turn)
	{
		if (turn == TurnManager.Turn.Player)
		{
			StartCoroutine(MoveToTargetAndAttack());
		}
	}

	private void UpdateAnimatorState()
	{
		animator.SetBool("Idle", Manager.Game.IsArrival);
	}

	public void TakeDamage(float damage)
	{
		float monsterDamage = damage - gameModel.CurrentDefense;
		gameModel.CurrentHealth -= monsterDamage;
		animator.SetTrigger("TakeHit");

		Vector3 worldPosition = transform.position + Vector3.up * 0.5f;
		Manager.UI.ShowDamageText(worldPosition, monsterDamage);

		if (gameModel.CurrentHealth <= 0)
		{
			Manager.Game.OnPlayerDeath?.Invoke();
			animator.SetBool("Die", true);
		}
	}

	public IEnumerator MoveToTargetAndAttack()
	{
		animator.SetBool("Idle", false);
		yield return MoveTo(Manager.Game.MonsterTargetX);
		animator.SetBool("Idle", true);
		animator.SetTrigger("Attack");
		yield return new WaitForSeconds(1f);
		animator.SetBool("Idle", false);
		yield return MoveTo(Manager.Game.PlayerOriginalX);

		if(!Manager.Game.IsArrival)
		{
			yield break;
		}

		animator.SetBool("Idle", true);

		Manager.Turn.CurrentTurn = TurnManager.Turn.Monster;
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
