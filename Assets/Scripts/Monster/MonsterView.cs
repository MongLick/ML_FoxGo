using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] MonsterModel model;
	[SerializeField] Slider healthSlider;
	[SerializeField] TMP_Text healthText;

	private void OnEnable()
	{
		model.OnCurrentHealth += UpdateHealthUI;
	}

	private void OnDisable()
	{
		model.OnCurrentHealth -= UpdateHealthUI;
	}

	public void UpdateHealthUI()
	{
		healthSlider.maxValue = model.MaxHealth;
		healthSlider.value = model.CurrentHealth;
		healthText.text = $"{model.CurrentHealth}";
	}
}
