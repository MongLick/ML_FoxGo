public class TitleScene : BaseScene
{
	private void OnEnable()
	{
		Manager.Game.IsArrival = false;
		Manager.Game.IsCombat = false;
		Manager.Game.DayCount = 1;
	}
}
