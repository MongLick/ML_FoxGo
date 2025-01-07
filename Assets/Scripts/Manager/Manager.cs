using UnityEngine;

public static class Manager
{
	public static GameManager Game { get { return GameManager.Instance; } }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
		GameManager.ReleaseInstance();
		GameManager.CreateInstance();
	}
}
