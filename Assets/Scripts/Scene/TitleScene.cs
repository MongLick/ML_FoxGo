public class TitleScene : BaseScene
{
	private void Start()
	{
		Manager.Sound.PlayBGM(Manager.Sound.TitleClip);
	}

	private void OnEnable()
	{
		Manager.Game.IsArrival = false;
		Manager.Game.IsCombat = false;
		Manager.Game.DayCount = 1;
	}
}
