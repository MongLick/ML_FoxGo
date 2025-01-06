using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameData[] uiPrefab;
	[SerializeField] GameData currentPrefab;
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameController gameController;

	[Header("Specs")]
	[SerializeField] float currentYPosition;
	[SerializeField] int randomIndex;

	private void Awake()
	{
		GameData newui = Instantiate(uiPrefab[0], scrollRect.content);
		currentPrefab = newui;
		RectTransform newuiRect = newui.GetComponent<RectTransform>();
		newuiRect.anchoredPosition = new Vector2(10f, -currentYPosition);
		currentYPosition += newui.Space;
	}

	public void AddLeftUiObject()
	{
		CreateNewUiObject(currentPrefab.LeftPrefab);
	}

	public void AddRightUiObject()
	{
		CreateNewUiObject(currentPrefab.RightPrefab);
	}

	public void AddVictoryUiObject()
	{
		int randomIndex = Random.Range(0, 6);
		CreateNewUiObject(currentPrefab.VictoryPrefab[randomIndex]);
	}

	public void AddNewUiObject()
	{
		if (currentPrefab.NextPrefab != null)
		{
			CreateNewUiObject(currentPrefab.NextPrefab);
			return;
		}

		if (currentPrefab.RandomPrefab.Length > 0)
		{
			randomIndex = Random.Range(0, currentPrefab.RandomPrefab.Length);
			CreateNewUiObject(currentPrefab.RandomPrefab[randomIndex]);
			return;
		}

		randomIndex = Random.Range(1, uiPrefab.Length);
		CreateNewUiObject(uiPrefab[randomIndex]);
	}

	private void CreateNewUiObject(GameData newuiPrefab)
	{
		GameData newui = Instantiate(newuiPrefab, scrollRect.content);
		currentPrefab = newui;

		gameController.ApplyUI(newui);
		UpdateScrollRect(newui);
	}

	private void UpdateScrollRect(GameData newui)
	{
		RectTransform newuiRect = newui.GetComponent<RectTransform>();

		float objectHeight = newuiRect.sizeDelta.y;

		newuiRect.anchoredPosition = new Vector2(10f, -currentYPosition);

		currentYPosition += objectHeight + newui.Space;

		scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, currentYPosition);
		scrollRect.verticalNormalizedPosition = 0f;
	}
}
