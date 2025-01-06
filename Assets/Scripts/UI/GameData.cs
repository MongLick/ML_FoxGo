using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
	public enum DataType { None, Experience, Health, MaxHealth, AttackPower, Defense }
	public enum DayType { None, NextDay }
	public enum PrefabType { None, Move, Daughter, Hut, Domain, Shaman, Obelisk, Monster, Angel }

	[Header("Components")]
	[SerializeField] TMP_Text dayText;
	public TMP_Text DayText { get { return dayText; } set { dayText = value; } }
	[SerializeField] GameData[] victoryPrefab;
	public GameData[] VictoryPrefab { get { return victoryPrefab; } }
	[SerializeField] GameData[] randomPrefab;
	public GameData[] RandomPrefab { get { return randomPrefab; } }
	[SerializeField] GameData nextPrefab;
	public GameData NextPrefab { get { return nextPrefab; } }
	[SerializeField] GameData leftPrefab;
	public GameData LeftPrefab { get { return leftPrefab; } }
	[SerializeField] GameData rightPrefab;
	public GameData RightPrefab { get { return rightPrefab; } }

	[Header("Specs")]
	[SerializeField] DataType[] dataTypes = new DataType[2];
	public DataType[] DataTypes { get { return dataTypes; } }
	[SerializeField] DayType dataDayType;
	public DayType DataDayType { get { return dataDayType; } }
	[SerializeField] PrefabType dataPrefabType;
	public PrefabType DataPrefabType { get { return dataPrefabType; } }
	[SerializeField] float[] values = new float[2];
	public float[] Values { get { return values; } }
	[SerializeField] float space;
	public float Space { get { return space; } }
}
