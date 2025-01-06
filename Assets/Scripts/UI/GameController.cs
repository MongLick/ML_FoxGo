using UnityEngine;
using static GameData;

public class GameController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameModel model;
	[SerializeField] GameView view;

	public void ApplyUI(GameData gameData)
	{
		UpdateSpecs(gameData);
		UpdateDay(gameData);
		UpdateButton(gameData);
		UpdateButtonText(gameData);
	}

	private void UpdateSpecs(GameData gameData)
	{
		for (int i = 0; i < gameData.DataTypes.Length; i++)
		{
			DataType dataType = gameData.DataTypes[i];
			float value = gameData.Values[i];

			switch (dataType)
			{
				case DataType.None:
					break;

				case DataType.Health:
					UpdateHealth(value);
					view.UpdateHealthUI(model.CurrentHealth, model.MaxHealth);
					break;

				case DataType.MaxHealth:
					UpdateMaxHealth(value);
					view.UpdateHealthUI(model.CurrentHealth, model.MaxHealth);
					break;

				case DataType.Experience:
					UpdateExperience(value);
					view.UpdateExperienceUI(model.CurrentExperience, model.MaxExperience);
					view.UpdateLevelUI(model.Level);
					break;

				case DataType.AttackPower:
					UpdateAttackPower(value);
					view.UpdateAttackPowerUI(model.CurrentAttackPower);
					break;

				case DataType.Defense:
					UpdateDefense(value);
					view.UpdateDefenseUI(model.CurrentDefense);
					break;
			}
		}
	}

	private void UpdateDay(GameData gameData)
	{
		DayType dayType = gameData.DataDayType;

		switch (dayType)
		{
			case DayType.None:
				break;

			case DayType.NextDay:
				UpdateDay();
				view.UpdateDayText(gameData, model.DayCount);
				break;
		}
	}

	private void UpdateExperience(float value)
	{
		model.CurrentExperience += value;

		while (model.CurrentExperience >= model.MaxExperience)
		{
			LevelUp();
		}
	}

	private void LevelUp()
	{
		model.Level++;
		model.CurrentExperience -= model.MaxExperience;
		if (model.CurrentExperience < 0) model.CurrentExperience = 0;
	}

	private void UpdateHealth(float value)
	{
		model.CurrentHealth = Mathf.Clamp(model.CurrentHealth + value, 0, model.MaxHealth);
	}

	private void UpdateMaxHealth(float value)
	{
		model.MaxHealth += value;
		model.CurrentHealth = Mathf.Min(model.CurrentHealth, model.MaxHealth);
	}

	private void UpdateAttackPower(float value)
	{
		model.CurrentAttackPower += value;
	}

	private void UpdateDefense(float value)
	{
		model.CurrentDefense += value;
	}

	private void UpdateDay()
	{
		model.DayCount++;
	}

	private void UpdateButton(GameData gameData)
	{
		view.UpdateButtonStates(gameData.LeftPrefab != null);
	}

	private void UpdateButtonText(GameData gameData)
	{
		PrefabType prefabType = gameData.DataPrefabType;

		switch (prefabType)
		{
			case PrefabType.None:
				view.UpdateDefaultButton("다음날", 0);
				break;
			case PrefabType.Move:
				view.UpdateDefaultButton("이동중", 1);
				break;
			case PrefabType.Daughter:
				view.UpdateDefaultButton("기도", 2);
				break;
			case PrefabType.Hut:
				view.UpdateChoiceButton("휴식", "수색", 2);
				break;
			case PrefabType.Domain:
				view.UpdateDefaultButton("휴식", 2);
				break;
			case PrefabType.Shaman:
				view.UpdateChoiceButton("체력↓", "공격력↓", 2);
				break;
			case PrefabType.Obelisk:
				view.UpdateDefaultButton("희생", 2);
				break;
			case PrefabType.Monster:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Angel:
				view.UpdateChoiceButton("공격력↑", "체력↑", 2);
				break;
		}
	}
}
