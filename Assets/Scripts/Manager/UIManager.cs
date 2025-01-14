using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	[Header("Components")]
	[SerializeField] PooledObject damageText;
	public PooledObject DamageText { get { return damageText; } }

	public void ShowDamageText(Vector3 worldPosition, float damageAmount)
	{
		PooledObject poolObject = Manager.Pool.GetPool(damageText, worldPosition, Quaternion.identity);

		DamageText damageTextScript = poolObject.GetComponent<DamageText>();
		damageTextScript.Initialize((int)damageAmount);
	}
}
