using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
	public enum DataType { Experience, Health, MaxHealth, AttackPower, Defense }
	public DataType dataType;

	[Header("Components")]
	[SerializeField] TMP_Text dayText;
	public TMP_Text DayText { get { return dayText; } set { dayText = value; } }

	[Header("Specs")]
	[SerializeField] float dataValue;
	public float DataValue { get { return dataValue; } set { dataValue = value; } }
}
