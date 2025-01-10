using UnityEngine;

public static class Manager
{
	public static GameManager Game { get { return GameManager.Instance; } }
	public static TurnManager Turn { get { return TurnManager.Instance; } }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
		GameManager.ReleaseInstance();
		GameManager.CreateInstance();

		TurnManager.ReleaseInstance();
		TurnManager.CreateInstance();
	}
}
