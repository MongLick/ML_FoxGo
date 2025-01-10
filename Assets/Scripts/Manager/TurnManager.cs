using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : Singleton<TurnManager>
{
	public enum Turn { None, Player, Monster }

	[Header("UnityAction")]
	private UnityAction<Turn> onTurnChanged;
	public UnityAction<Turn> OnTurnChanged { get { return onTurnChanged; } set { onTurnChanged = value; } }

	[Header("Specs")]
	[SerializeField] Turn currentTurn;
	public Turn CurrentTurn { get { return currentTurn; } set { currentTurn = value; onTurnChanged?.Invoke(currentTurn); } }
}
