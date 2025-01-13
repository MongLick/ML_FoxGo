using TMPro;
using UnityEngine;

public class TextBoxData : MonoBehaviour
{
	public enum DataType { None, Experience, Health, MaxHealth, AttackPower, Defense }
	public enum DayType { None, NextDay }
	public enum PrefabType { None, Move, Daughter, Hut, Domain, Shaman, Obelisk, Adventurer, Skeleton, Warrior, Necromancer, Demon, Knight, Swordsman, Wizard, StrongKnight, Paladin }

	[Header("Components")]
	[SerializeField] TMP_Text dayText;
	public TMP_Text DayText { get { return dayText; } set { dayText = value; } }
	[SerializeField] TextBoxData[] randomPrefab;
	public TextBoxData[] RandomPrefab { get { return randomPrefab; } }
	[SerializeField] TextBoxData nextPrefab;
	public TextBoxData NextPrefab { get { return nextPrefab; } }
	[SerializeField] TextBoxData leftPrefab;
	public TextBoxData LeftPrefab { get { return leftPrefab; } }
	[SerializeField] TextBoxData rightPrefab;
	public TextBoxData RightPrefab { get { return rightPrefab; } }

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
