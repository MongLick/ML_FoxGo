using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] ScrollRect scrollRect;
	[SerializeField] GameObject[] uiPrefab;
	[SerializeField] List<RectTransform> uiObjects = new List<RectTransform>();

	[Header("Specs")]
	[SerializeField] float space;

	public void AddNewUiObject()
	{
		int randomIndex = Random.Range(0, uiPrefab.Length);
		RectTransform newui = Instantiate(uiPrefab[randomIndex], scrollRect.content).GetComponent<RectTransform>();
		uiObjects.Add(newui);

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
