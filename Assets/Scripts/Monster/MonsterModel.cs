using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterModel : MonoBehaviour
{
	[Header("UnityAction")]
	private UnityAction onCurrentHealth;
	public UnityAction OnCurrentHealth { get { return onCurrentHealth; } set { onCurrentHealth = value; } }

	[Header("Specs")]
	[SerializeField] float moveSpeed;
	public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
	[SerializeField] float maxHealth;
	public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
	[SerializeField] float currentHealth;
	public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; onCurrentHealth?.Invoke(); } }
	[SerializeField] float damage;
	public float Damage { get { return damage; } set { damage = value; } }
	[SerializeField] float fadeDuration;
	public float FadeDuration { get { return fadeDuration; } set { fadeDuration = value; } }
}
