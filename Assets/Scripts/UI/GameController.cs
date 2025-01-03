using UnityEngine;
using static GameData;

public class GameController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameModel model;
	[SerializeField] GameView view;

	public void ApplyUI(GameData gameData)
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
					model.UpdateHealth(value);
					view.UpdateHealthUI(model.CurrentHealth, model.MaxHealth);
					break;

				case DataType.MaxHealth:
					model.UpdateMaxHealth(value);
					view.UpdateHealthUI(model.CurrentHealth, model.MaxHealth);
					break;

				case DataType.Experience:
					model.UpdateExperience(value);
					view.UpdateExperienceUI(model.CurrentExperience, model.MaxExperience);
					view.UpdateLevelUI(model.Level);
					break;

				case DataType.AttackPower:
					model.UpdateAttackPower(value);
					view.UpdateAttackPowerUI(model.CurrentAttackPower);
					break;

				case DataType.Defense:
					model.UpdateDefense(value);
					view.UpdateDefenseUI(model.CurrentDefense);
					break;
			}
		}

		model.DayCount++;
		gameData.DayText.text = $"{model.DayCount} ÀÏÂ÷";
	}
}
