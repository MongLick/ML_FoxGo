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
		Manager.Scene.LoadScene("GameScene");
	}
}