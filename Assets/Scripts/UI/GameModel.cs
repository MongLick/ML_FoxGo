using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
	[Header("Specs")]
	[SerializeField] float currentHealth;
	public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
	[SerializeField] float maxHealth;
	public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
	[SerializeField] float currentExperience;
	public float CurrentExperience { get { return currentExperience; } set { currentExperience = value; } }
	[SerializeField] float maxExperience;
	public float MaxExperience { get { return maxExperience; } set { maxExperience = value; } }
	[SerializeField] float level;
	public float Level { get { return level; } set { level = value; } }
	[SerializeField] float currentAttackPower;
	public float CurrentAttackPower { get { return currentAttackPower; } set { currentAttackPower = value; } }
	[SerializeField] float currentDefense;
	public float CurrentDefense { get { return currentDefense; } set { currentDefense = value; } }
	[SerializeField] int dayCount;
	public int DayCount { get { return dayCount; } set { dayCount = value; } }

	public void UpdateExperience(float value)
	{
		CurrentExperience += value;

		while (CurrentExperience >= MaxExperience)
		{
			LevelUp();
		}
	}

	private void LevelUp()
	{
		Level++;
		CurrentExperience -= MaxExperience; 
		if (CurrentExperience < 0) CurrentExperience = 0;
	}

	public void UpdateHealth(float value)
	{
		CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, MaxHealth);
	}

	public void UpdateMaxHealth(float value)
	{
		MaxHealth += value;
		CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);
	}

	public void UpdateAttackPower(float value)
	{
		CurrentAttackPower += value;
	}

	public void UpdateDefense(float value)
	{
		CurrentDefense += value;
	}
}
