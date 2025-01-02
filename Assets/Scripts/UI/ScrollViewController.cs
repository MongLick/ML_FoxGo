using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] List<RectTransform> uiObjects = new List<RectTransform>();
	[SerializeField] GameObject[] uiPrefab;
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameController gameController;

	[Header("Specs")]
	[SerializeField] float space;

	private void Awake()
	{
		RectTransform newui = Instantiate(uiPrefab[0], scrollRect.content).GetComponent<RectTransform>();
		uiObjects.Add(newui);
	}

	public void AddNewUiObject()
	{
		int randomIndex = Random.Range(1, uiPrefab.Length);
		RectTransform newui = Instantiate(uiPrefab[randomIndex], scrollRect.content).GetComponent<RectTransform>();
		uiObjects.Add(newui);

		GameData gameData = newui.GetComponent<GameData>();
		if (gameData != null)
		{
			gameController.ApplyUI(gameData);
		}

		float y = 0f;
		for(int i = 0; i < uiObjects.Count; i++)
		{
			uiObjects[i].anchoredPosition = new Vector2(0f, -y);
			y += uiObjects[i].sizeDelta.y + space;
		}

		scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, y);
		scrollRect.verticalNormalizedPosition = 0f;
	}
}
