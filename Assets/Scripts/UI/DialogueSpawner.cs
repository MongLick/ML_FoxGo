using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpawner : MonoBehaviour
{
	[Header("Components")]
	public GameObject[] dialoguePrefabs; 
	public Transform content;   

	public void SpawnRandomDialogue()
	{
		int randomIndex = Random.Range(0, dialoguePrefabs.Length);

		GameObject newDialogue = Instantiate(dialoguePrefabs[randomIndex], content);
	}
}
