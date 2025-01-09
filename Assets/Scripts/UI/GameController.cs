using System.Collections;
using UnityEngine;
using static TextBoxData;

public class GameController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] ScrollViewController scrollViewController;
	[SerializeField] GameModel model;
	[SerializeField] GameView view;
	[SerializeField] ObjectSpawner spawner;

	public void SpawnWithDelay(TextBoxData boxData)
	{
		GameObject spawnedObject = spawner.Spawn(boxData);

		if (spawnedObject != null)
		{
			StartCoroutine(WaitForCompletionAndUpdateUI(spawnedObject, boxData));
		}
		else
		{
			ApplyUI(boxData);
		}
	}

	private void ApplyUI(TextBoxData boxData)
	{
		UpdateSpecs(boxData);
		UpdateDay(boxData);
		UpdateButton(boxData);
		UpdateButtonText(boxData);
		scrollViewController.CreateBoxObject(boxData);
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
				view.UpdateDefaultButton("������", 0);
				break;
			case PrefabType.Move:
				view.UpdateDefaultButton("�̵��ϱ�", 1);
				model.IsMoveButtonOn = true;
				break;
			case PrefabType.Daughter:
				view.UpdateDefaultButton("�⵵", 2);
				break;
			case PrefabType.Hut:
				view.UpdateChoiceButton("�޽�", "����", 2);
				break;
			case PrefabType.Domain:
				view.UpdateDefaultButton("�޽�", 2);
				break;
			case PrefabType.Shaman:
				view.UpdateChoiceButton("ü�¡�", "���ݷ¡�", 2);
				break;
			case PrefabType.Obelisk:
				view.UpdateDefaultButton("���", 2);
				break;
			case PrefabType.Adventurer:
				view.UpdateChoiceButton("���ݷ¡�", "ü�¡�", 2);
				break;
			case PrefabType.Skeleton:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Warrior:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Necromancer:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Demon:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Knight:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Swordsman:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Wizard:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.StrongKnight:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
			case PrefabType.Paladin:
				view.UpdateDefaultButton("�����ϱ�", 3);
				break;
		}
	}

	public void ObjectSpawn(TextBoxData bosData)
	{
		spawner.Spawn(bosData);
	}

	public void DefaultButtonCheck()
	{
		if (model.IsMoveButtonClick)
		{
			view.UpdateDefaultButton("�̵���", 1);
			view.SetButtonInteractable(false);
			StartCoroutine(MoveToDestination());
		}

		if (model.IsMoveButtonOn)
		{
			model.IsMoveButtonClick = true;
		}
	}

	private IEnumerator WaitForCompletionAndUpdateUI(GameObject spawnedObject, TextBoxData boxData)
	{
		ParallaxNPC npc = spawnedObject.GetComponent<ParallaxNPC>();

		if (npc == null)
		{
			yield break;
		}

		yield return new WaitUntil(() => npc.IsCompletion);

		ApplyUI(boxData);
	}

	private IEnumerator MoveToDestination()
	{
		yield return new WaitUntil(() => Manager.Game.IsArrival);
		view.SetButtonInteractable(true);
		model.IsMoveButtonOn = false;
		model.IsMoveButtonClick = false;
	}
}
