public class GameScene : BaseScene
{
	private void Start()
	{
		Manager.Sound.PlayBGM(Manager.Sound.GameClip);
		Manager.Pool.CreatePool(Manager.UI.DamageText, 1, 2);
	}
}
