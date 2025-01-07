using UnityEngine;
using static TextBoxData;

public class GameController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameModel model;
	[SerializeField] GameView view;
	[SerializeField] ObjectSpawner spawner;

	public void ApplyUI(TextBoxData boxData)
	{
		UpdateSpecs(boxData);
		UpdateDay(boxData);
		UpdateButton(boxData);
		UpdateButtonText(boxData);
		ObjectSpawn(boxData);
	}

	private void UpdateSpecs(TextBoxData boxData)
	{
		for (int i = 0; i < boxData.DataTypes.Length; i++)
		{
			DataType dataType = boxData.DataTypes[i];
			float value = boxData.Values[i];

			switch (dataType)
			{
				case DataType.None:
					break;

				case DataType.Health:
					UpdateHealth(value);
					break;

				case DataType.MaxHealth:
					UpdateMaxHealth(value);
					break;

				case DataType.Experience:
					UpdateExperience(value);
					break;

				case DataType.AttackPower:
					UpdateAttackPower(value);
					break;

				case DataType.Defense:
					UpdateDefense(value);
					break;
			}
		}
	}

	private void UpdateDay(TextBoxData boxData)
	{
		DayType dayType = boxData.DataDayType;

		switch (dayType)
		{
			case DayType.None:
				break;

			case DayType.NextDay:
				UpdateDay();
				view.UpdateDayText(boxData);
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

	private void UpdateButton(TextBoxData bosData)
	{
		view.UpdateButtonStates(bosData.LeftPrefab != null);
	}

	private void UpdateButtonText(TextBoxData gameData)
	{
		PrefabType prefabType = gameData.DataPrefabType;

		switch (prefabType)
		{
			case PrefabType.None:
				view.UpdateDefaultButton("다음날", 0);
				break;
			case PrefabType.Move:
				view.UpdateDefaultButton("이동하기", 1);
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
			case PrefabType.Adventurer:
				view.UpdateChoiceButton("공격력↑", "체력↑", 2);
				break;
			case PrefabType.Skeleton:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Warrior:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Necromancer:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Demon:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Knight:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Swordsman:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Wizard:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.StrongKnight:
				view.UpdateDefaultButton("전투중", 3);
				break;
			case PrefabType.Paladin:
				view.UpdateDefaultButton("전투중", 3);
				break;
		}
	}

	private void ObjectSpawn(TextBoxData bosData)
	{
		spawner.Spawn(bosData);
	}
}
