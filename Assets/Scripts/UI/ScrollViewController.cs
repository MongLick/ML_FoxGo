using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameData[] uiPrefab;
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameController gameController;

	[Header("Specs")]
	[SerializeField] float currentYPosition;

	private void Awake()
	{
		GameData newui = Instantiate(uiPrefab[0], scrollRect.content);
		RectTransform newuiRect = newui.GetComponent<RectTransform>();
		newuiRect.anchoredPosition = new Vector2(10f, -currentYPosition);
		currentYPosition += newui.Space;
	}

	public void AddNewUiObject()
	{
		int randomIndex = Random.Range(1, uiPrefab.Length);
		CreateNewUiObject(uiPrefab[randomIndex]);
	}

	private void CreateNewUiObject(GameData newuiPrefab)
	{
		GameData newui = Instantiate(newuiPrefab, scrollRect.content);

		gameController.ApplyUI(newui);

		RectTransform newuiRect = newui.GetComponent<RectTransform>();

		float objectHeight = newuiRect.sizeDelta.y;

		newuiRect.anchoredPosition = new Vector2(10f, -currentYPosition);

		currentYPosition += objectHeight + newui.Space;

		scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, currentYPosition);

		scrollRect.verticalNormalizedPosition = 0f;
	}
}
