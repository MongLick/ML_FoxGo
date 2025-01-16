using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameModel : MonoBehaviour
{
	[Header("UnityAction")]
	private UnityAction onCurrentHealth;
	public UnityAction OnCurrentHealth { get { return onCurrentHealth; } set { onCurrentHealth = value; } }
	private UnityAction onMaxHealth;
	public UnityAction OnMaxHealth { get { return onMaxHealth; } set { onMaxHealth = value; } }
	private UnityAction onCurrentExperience;
	public UnityAction OnCurrentExperience { get { return onCurrentExperience; } set { onCurrentExperience = value; } }
	private UnityAction onMaxExperience;
	public UnityAction OnMaxExperience { get { return onMaxExperience; } set { onMaxExperience = value; } }
	private UnityAction onLevel;
	public UnityAction OnLevel { get { return onLevel; } set { onLevel = value; } }
	private UnityAction onCurrentAttackPower;
	public UnityAction OnCurrentAttackPower { get { return onCurrentAttackPower; } set { onCurrentAttackPower = value; } }
	private UnityAction onCurrentDefense;
	public UnityAction OnCurrentDefense { get { return onCurrentDefense; } set { onCurrentDefense = value; } }

	[Header("Specs")]
	[SerializeField] float currentHealth;
	public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; onCurrentHealth?.Invoke(); } }
	[SerializeField] float maxHealth;
	public float MaxHealth { get { return maxHealth; } set { maxHealth = value; onMaxHealth?.Invoke(); } }
	[SerializeField] float currentExperience;
	public float CurrentExperience { get { return currentExperience; } set { currentExperience = value; onCurrentExperience?.Invoke(); } }
	[SerializeField] float maxExperience;
	public float MaxExperience { get { return maxExperience; } set { maxExperience = value; onMaxExperience?.Invoke(); } }
	[SerializeField] float level;
	public float Level { get { return level; } set { level = value; onLevel?.Invoke(); } }
	[SerializeField] float currentAttackPower;
	public float CurrentAttackPower { get { return currentAttackPower; } set { currentAttackPower = value; onCurrentAttackPower?.Invoke(); } }
	[SerializeField] float currentDefense;
	public float CurrentDefense { get { return currentDefense; } set { currentDefense = value; onCurrentDefense?.Invoke(); } }
	[SerializeField] bool isMoveButtonOn;
	public bool IsMoveButtonOn { get { return isMoveButtonOn; } set { isMoveButtonOn = value; } }
	[SerializeField] bool isMoveButtonClick;
	public bool IsMoveButtonClick { get { return isMoveButtonClick; } set { isMoveButtonClick = value; } }
}
