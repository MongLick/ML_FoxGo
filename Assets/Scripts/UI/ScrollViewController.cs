using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] TextBoxData[] boxData;
	[SerializeField] TextBoxData[] victoryBoxData;
	[SerializeField] TextBoxData currentBoxData;
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameController gameController;

	[Header("Specs")]
	[SerializeField] float currentYPosition;
	[SerializeField] int randomIndex;

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

		randomIndex = Random.Range(1, boxData.Length);
		CreateNewUiObject(boxData[randomIndex]);
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
