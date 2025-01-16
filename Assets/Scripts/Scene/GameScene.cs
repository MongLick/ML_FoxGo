using System.Collections;

public class GameScene : BaseScene
{
	private void Start()
	{
		Manager.Pool.CreatePool(Manager.UI.DamageText, 1, 2);
	}
}
