using UnityEngine;
using static GameData;

public class GameController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameModel model;
	[SerializeField] GameView view;

	public void ApplyUI(GameData gameData)
	{
		switch (gameData.dataType)
		{
			case DataType.Health:
				model.UpdateHealth(gameData.DataValue);
				view.UpdateHealthUI(model.CurrentHealth, model.MaxHealth);
				break;

			case DataType.MaxHealth:
				model.UpdateMaxHealth(gameData.DataValue);
				view.UpdateHealthUI(model.CurrentHealth, model.MaxHealth);
				break;

			case DataType.Experience:
				model.UpdateExperience(gameData.DataValue);
				view.UpdateExperienceUI(model.CurrentExperience, model.MaxExperience);
				view.UpdateLevelUI(model.Level);
				view.UpdateExperienceUI(model.CurrentExperience, model.MaxExperience);
				break;

			case DataType.AttackPower:
				model.UpdateAttackPower(gameData.DataValue);
				view.UpdateAttackPowerUI(model.CurrentAttackPower);
				break;

			case DataType.Defense:
				model.UpdateDefense(gameData.DataValue);
				view.UpdateDefenseUI(model.CurrentDefense);
				break;
		}

		model.DayCount++;
		gameData.DayText.text = $"{model.DayCount} ÀÏÂ÷";
	}
}
