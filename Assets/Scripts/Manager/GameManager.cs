using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
	[Header("UnityAction")]
	private UnityAction onArrivalStateChanged;
	public UnityAction OnArrivalStateChanged { get { return onArrivalStateChanged; } set { onArrivalStateChanged = value; } }
	private UnityAction onPlayerDeath;
	public UnityAction OnPlayerDeath { get { return onPlayerDeath; } set { onPlayerDeath = value; } }
	private UnityAction onMonsterDeath;
	public UnityAction OnMonsterDeath { get { return onMonsterDeath; } set { onMonsterDeath = value; } }
	
	[Header("Specs")]
	[SerializeField] float playerOriginalX;
	public float PlayerOriginalX { get { return playerOriginalX; } }
	[SerializeField] float playerTargetX;
	public float PlayerTargetX { get { return playerTargetX; } }
	[SerializeField] float monsterOriginalX;
	public float MonsterOriginalX { get { return monsterOriginalX; } }
	[SerializeField] float monsterTargetX;
	public float MonsterTargetX { get { return monsterTargetX; } }
	[SerializeField] int dayCount;
	public int DayCount { get { return dayCount; } set { dayCount = value; } }
	[SerializeField] bool isArrival;
	public bool IsArrival { get { return isArrival; } set { isArrival = value; onArrivalStateChanged?.Invoke(); } }
	[SerializeField] bool isCombat;
	public bool IsCombat { get { return isCombat; } set { isCombat = value; } }
}
