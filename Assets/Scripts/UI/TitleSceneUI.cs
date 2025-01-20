using UnityEngine;
using UnityEngine.UI;

public class TitleSceneUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button GameStartButton;

	private void Awake()
	{
		GameStartButton.onClick.AddListener(GameStart);
	}

	private void GameStart()
	{
		Manager.Sound.PlaySFX(Manager.Sound.UiButtonClip);
		Manager.Scene.LoadScene("GameScene");
	}
}
