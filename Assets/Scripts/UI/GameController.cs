using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using static TextBoxData;

public class GameController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] ScrollViewController scrollViewController;
	[SerializeField] GameModel model;
	[SerializeField] GameView view;
	[SerializeField] ObjectSpawner spawner;

	private void OnEnable()
	{
		Manager.Game.OnMonsterDeath += MonsterDeath;
	}

	private void OnDisable()
	{
		Manager.Game.OnMonsterDeath -= MonsterDeath;
	}

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

		HashSet<PrefabType> combatPrefabTypes = new HashSet<PrefabType>
	{
		PrefabType.Skeleton,
		PrefabType.Warrior,
		PrefabType.Necromancer,
		PrefabType.Demon,
		PrefabType.Knight,
		PrefabType.Swordsman,
		PrefabType.Wizard,
		PrefabType.StrongKnight,
		PrefabType.Paladin
	};

		if (combatPrefabTypes.Contains(prefabType))
		{
			Manager.Game.IsCombat = true;
			return;
		}

		switch (prefabType)
		{
			case PrefabType.None:
				view.UpdateDefaultButton("다음날", 0);
				break;
			case PrefabType.Move:
				view.UpdateDefaultButton("이동하기", 1);
				model.IsMoveButtonOn = true;
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
			view.UpdateDefaultButton("이동중", 1);
			view.SetButtonInteractable(false);
			StartCoroutine(MoveToDestination());
		}

		if (model.IsMoveButtonOn)
		{
			model.IsMoveButtonClick = true;
		}
	}

	public void StartCombat()
	{
		view.UpdateDefaultButton("전투중", 3);
		view.SetButtonInteractable(false);
	}

	private void EndCombat()
	{
		view.UpdateDefaultButton("다음날", 0);
		view.SetButtonInteractable(true);
		Manager.Game.IsCombat = false;
		Manager.Game.IsArrival = false;
	}

	private void MonsterDeath()
	{
		scrollViewController.AddVictoryUiObject();

		StartCoroutine(CombatCoroutine());
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

		if(Manager.Game.IsCombat)
		{
			StartCombat();
		}
	}

	private IEnumerator CombatCoroutine()
	{
		yield return new WaitForSeconds(1.5f);
		EndCombat();
	}
}
