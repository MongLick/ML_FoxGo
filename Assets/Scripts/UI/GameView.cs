using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameModel model;
	[SerializeField] Sprite[] buttonSprites;
	[SerializeField] Image victoryUI;
	[SerializeField] Image defeatUI;
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

	private void OnEnable()
	{
		model.OnCurrentHealth += UpdateHealthUI;
		model.OnMaxHealth += UpdateHealthUI;
		model.OnCurrentExperience += UpdateExperienceUI;
		model.OnMaxExperience += UpdateExperienceUI;
		model.OnLevel += UpdateLevelUI;
		model.OnCurrentAttackPower += UpdateAttackPowerUI;
		model.OnCurrentDefense += UpdateDefenseUI;
		Manager.Game.OnPlayerDeath += UpdateDefeatUI;
		Manager.Game.OnMonsterDeath += UpdateVictoryUI;
	}

	private void OnDisable()
	{
		model.OnCurrentHealth -= UpdateHealthUI;
		model.OnMaxHealth -= UpdateHealthUI;
		model.OnCurrentExperience -= UpdateExperienceUI;
		model.OnMaxExperience -= UpdateExperienceUI;
		model.OnLevel -= UpdateLevelUI;
		model.OnCurrentAttackPower -= UpdateAttackPowerUI;
		model.OnCurrentDefense -= UpdateDefenseUI;
		Manager.Game.OnPlayerDeath -= UpdateDefeatUI;
		Manager.Game.OnMonsterDeath -= UpdateVictoryUI;
	}

	public void UpdateHealthUI()
	{
		healthSlider.maxValue = model.MaxHealth;
		healthSlider.value = model.CurrentHealth;
		healthText.text = $"{model.CurrentHealth}/{model.MaxHealth}";
	}

	public void UpdateExperienceUI()
	{
		experienceSlider.maxValue = model.MaxExperience;
		experienceSlider.value = model.CurrentExperience;
	}

	public void UpdateLevelUI()
	{
		levelText.text = $"LV.{model.Level}";
	}

	public void UpdateAttackPowerUI()
	{
		attackPowerText.text = $"{model.CurrentAttackPower}";
	}

	public void UpdateDefenseUI()
	{
		defenseText.text = $"{model.CurrentDefense}";
	}

	public void UpdateDayText(TextBoxData boxData)
	{
		boxData.DayText.text = $"{Manager.Game.DayCount} ÀÏÂ÷";
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

	public void SetButtonInteractable(bool interactable)
	{
		defaultButton.interactable = interactable;
	}

	private void UpdateVictoryUI()
	{
		if (Manager.Game.DayCount == 45)
		{
			StartCoroutine(ShowUI(victoryUI));
		}
	}

	private void UpdateDefeatUI()
	{
		StartCoroutine(ShowUI(defeatUI));
	}

	private IEnumerator ShowUI(Image image)
	{
		yield return new WaitForSeconds(1f);

		Time.timeScale = 0f;

		image.gameObject.SetActive(true);
	}

}
