using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
	private void Start()
	{
		Manager.Pool.CreatePool(Manager.UI.DamageText, 1, 2);
	}
}
