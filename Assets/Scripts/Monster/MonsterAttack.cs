using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] MonsterController monster;

	[Header("Specs")]
	[SerializeField] LayerMask layer;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (layer.Contain(collision.gameObject.layer))
		{
			IDamageable damageable = collision.GetComponent<IDamageable>();
			if (damageable != null)
			{
				damageable.TakeDamage(monster.Damage);
			}
		}
	}
}
