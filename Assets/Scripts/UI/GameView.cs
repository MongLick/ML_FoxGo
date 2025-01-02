using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Slider experienceSlider;
	[SerializeField] Slider healthSlider;
	[SerializeField] TMP_Text levelText;
	[SerializeField] TMP_Text healthText;
	[SerializeField] TMP_Text attackPowerText;
	[SerializeField] TMP_Text defenseText;

	public void UpdateHealthUI(float currentHealth, float maxHealth)
	{
		healthSlider.maxValue = maxHealth;
		healthSlider.value = currentHealth;
		healthText.text = $"{currentHealth}/{maxHealth}";
	}

	public void UpdateExperienceUI(float currentExperience, float maxExperience)
	{
		experienceSlider.maxValue = maxExperience;
		experienceSlider.value = currentExperience;
	}

	public void UpdateLevelUI(float level)
	{
		levelText.text = $"LV.{level}";
	}

	public void UpdateAttackPowerUI(float attackPower)
	{
		attackPowerText.text = $"{attackPower}";
	}

	public void UpdateDefenseUI(float defense) 
	{
		defenseText.text = $"{defense}";
	}
}
