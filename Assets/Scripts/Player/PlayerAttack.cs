using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameModel gameModel;

	[Header("Specs")]
	[SerializeField] LayerMask layer;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (layer.Contain(collision.gameObject.layer))
		{
			IDamageable damageable = collision.GetComponent<IDamageable>();
			if (damageable != null)
			{
				damageable.TakeDamage(gameModel.CurrentAttackPower);
			}
		}
	}
}
