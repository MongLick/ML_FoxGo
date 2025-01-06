using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Sprite[] buttonSprites;
	[SerializeField] Slider experienceSlider;
	[SerializeField] Slider healthSlider;
	[SerializeField] Button defaultButton;
	[SerializeField] Button leftButton;
	[SerializeField] Button rightButton;
	[SerializeField] TMP_Text levelText;
	[SerializeField] TMP_Text healthText;
	[SerializeField] TMP_Text attackPowerText;
	[SerializeField] TMP_Text defenseText;
	[SerializeField] TMP_Text defaultText;
	[SerializeField] TMP_Text leftText;
	[SerializeField] TMP_Text rightText;

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

	public void UpdateDayText(GameData gameData, int datCount)
	{
		gameData.DayText.text = $"{datCount} ÀÏÂ÷";
	}

	public void UpdateButtonStates(bool isChoice)
	{
		defaultButton.gameObject.SetActive(!isChoice);
		leftButton.gameObject.SetActive(isChoice);
		rightButton.gameObject.SetActive(isChoice);
	}

	public void UpdateDefaultButton(string text, int number)
	{
		defaultText.text = text;
		defaultButton.image.sprite = buttonSprites[number];
	}

	public void UpdateChoiceButton(string left, string right, int number)
	{
		leftText.text = left;
		rightText.text = right;
		leftButton.image.sprite = buttonSprites[number];
		rightButton.image.sprite = buttonSprites[number];
	}
}
