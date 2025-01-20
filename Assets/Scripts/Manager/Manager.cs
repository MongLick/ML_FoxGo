using UnityEngine;

public static class Manager
{
	public static GameManager Game { get { return GameManager.Instance; } }
	public static TurnManager Turn { get { return TurnManager.Instance; } }
	public static UIManager UI { get { return UIManager.Instance; } }
	public static PoolManager Pool { get { return PoolManager.Instance; } }
	public static SceneManager Scene { get { return SceneManager.Instance; } }
	public static SoundManager Sound { get { return SoundManager.Instance; } }
	public static SkillManager Skill { get { return SkillManager.Instance; } }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
		GameManager.ReleaseInstance();
		GameManager.CreateInstance();

		TurnManager.ReleaseInstance();
		TurnManager.CreateInstance();

		UIManager.ReleaseInstance();
		UIManager.CreateInstance();

		PoolManager.ReleaseInstance();
		PoolManager.CreateInstance();

		SceneManager.ReleaseInstance();
		SceneManager.CreateInstance();

		SoundManager.ReleaseInstance();
		SoundManager.CreateInstance();

		SkillManager.ReleaseInstance();
		SkillManager.CreateInstance();
	}
}
