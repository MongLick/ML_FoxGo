using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	private List<int> usedMonsterIndexes = new List<int>();

	[Header("Components")]
	[SerializeField] TextBoxData[] boxData;
	[SerializeField] TextBoxData[] victoryBoxData;
	[SerializeField] TextBoxData[] monsterBoxData;
	[SerializeField] TextBoxData currentBoxData;
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameController gameController;

	[Header("Specs")]
	[SerializeField] float currentYPosition;
	[SerializeField] int randomIndex;
	[SerializeField] int specialMonsterIndex;

	private void Awake()
	{
		TextBoxData newBoxData = Instantiate(boxData[0], scrollRect.content);
		currentBoxData = newBoxData;
		RectTransform boxRect = newBoxData.GetComponent<RectTransform>();
		boxRect.anchoredPosition = new Vector2(10f, -currentYPosition);
		currentYPosition += newBoxData.Space;
	}

	public void AddLeftUiObject()
	{
		Manager.Game.IsArrival = false;
		CreateNewUiObject(currentBoxData.LeftPrefab);
	}

	public void AddRightUiObject()
	{
		Manager.Game.IsArrival = false;
		CreateNewUiObject(currentBoxData.RightPrefab);
	}

	public void AddVictoryUiObject()
	{
		int randomIndex = Random.Range(0, 6);
		CreateNewUiObject(victoryBoxData[randomIndex]);
	}

	public void AddNewUiObject()
	{
		Manager.Game.IsArrival = false;

		if (currentBoxData.NextPrefab != null)
		{
			CreateNewUiObject(currentBoxData.NextPrefab);
			return;
		}

		if (currentBoxData.RandomPrefab.Length > 0)
		{
			randomIndex = Random.Range(0, currentBoxData.RandomPrefab.Length);
			CreateNewUiObject(currentBoxData.RandomPrefab[randomIndex]);
			return;
		}

		if ((Manager.Game.DayCount + 1) % 15 == 0)
		{
			if (specialMonsterIndex < monsterBoxData.Length)
			{
				CreateNewUiObject(monsterBoxData[specialMonsterIndex]);
				specialMonsterIndex++;
			}
			return;
		}

		if ((Manager.Game.DayCount + 1) % 5 == 0)
		{
			int monsterIndex = GetRandomMonsterIndex();
			if (monsterIndex != -1)
			{
				CreateNewUiObject(monsterBoxData[monsterIndex]);
			}
			return;
		}

		randomIndex = Random.Range(1, boxData.Length);
		CreateNewUiObject(boxData[randomIndex]);
	}

	private int GetRandomMonsterIndex()
	{
		List<int> availableIndexes = new List<int>();

		for (int i = 0; i < 6; i++)
		{
			if (!usedMonsterIndexes.Contains(i))
			{
				availableIndexes.Add(i);
			}
		}

		int randomIndex = availableIndexes[Random.Range(0, availableIndexes.Count)];
		usedMonsterIndexes.Add(randomIndex);
		return randomIndex;
	}

	private void CreateNewUiObject(TextBoxData boxData)
	{
		gameController.SpawnWithDelay(boxData);
	}

	public void CreateBoxObject(TextBoxData boxData)
	{
		TextBoxData newboxData = Instantiate(boxData, scrollRect.content);
		currentBoxData = newboxData;
		UpdateScrollRect(newboxData);
	}

	private void UpdateScrollRect(TextBoxData boxData)
	{
		RectTransform boxRect = boxData.GetComponent<RectTransform>();

		float objectHeight = boxRect.sizeDelta.y;

		boxRect.anchoredPosition = new Vector2(10f, -currentYPosition);

		currentYPosition += objectHeight + boxData.Space;

		scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, currentYPosition);
		scrollRect.verticalNormalizedPosition = 0f;
	}
}
