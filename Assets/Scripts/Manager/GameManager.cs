using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[Header("Specs")]
	[SerializeField] bool isArrival;
	public bool IsArrival { get { return isArrival; } set { isArrival = value; } }
}
