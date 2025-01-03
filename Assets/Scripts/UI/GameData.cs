using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
	public enum DataType { None, Experience, Health, MaxHealth, AttackPower, Defense }

	[Header("Components")]
	[SerializeField] TMP_Text dayText;
	public TMP_Text DayText { get { return dayText; } set { dayText = value; } }

	[Header("Specs")]
	[SerializeField] DataType[] dataTypes = new DataType[2];
	public DataType[] DataTypes { get { return dataTypes; } }
	[SerializeField] float[] values = new float[2];
	public float[] Values { get { return values; } }
	[SerializeField] float space;
	public float Space { get { return space; } }
}
