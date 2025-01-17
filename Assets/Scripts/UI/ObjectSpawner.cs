using System.Collections.Generic;
using UnityEngine;
using static TextBoxData;

public class ObjectSpawner : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameObject[] objectPrefab;

	[Header("Vector")]
	[SerializeField] Vector3[] spawnPosition;

	Dictionary<PrefabType, (GameObject prefab, Vector3 spawnPosition)> prefabDict;

	private void Awake()
	{
		prefabDict = new Dictionary<PrefabType, (GameObject, Vector3)>
		{
			{ PrefabType.Daughter, (objectPrefab[0], spawnPosition[0]) },
			{ PrefabType.Hut, (objectPrefab[1], spawnPosition[1]) },
			{ PrefabType.Domain, (objectPrefab[2], spawnPosition[2]) },
			{ PrefabType.Shaman, (objectPrefab[3], spawnPosition[3]) },
			{ PrefabType.Obelisk, (objectPrefab[4], spawnPosition[4]) },
			{ PrefabType.Adventurer, (objectPrefab[5], spawnPosition[5]) },
			{ PrefabType.Skeleton, (objectPrefab[6], spawnPosition[6]) },
			{ PrefabType.Warrior, (objectPrefab[7], spawnPosition[7]) },
			{ PrefabType.Necromancer, (objectPrefab[8], spawnPosition[8]) },
			{ PrefabType.Demon, (objectPrefab[9], spawnPosition[9]) },
			{ PrefabType.Knight, (objectPrefab[10], spawnPosition[10]) },
			{ PrefabType.Swordsman, (objectPrefab[11], spawnPosition[11]) },
			{ PrefabType.Wizard, (objectPrefab[12], spawnPosition[12]) },
			{ PrefabType.StrongKnight, (objectPrefab[13], spawnPosition[13]) },
			{ PrefabType.Paladin, (objectPrefab[14], spawnPosition[14]) }
		};
	}

	public GameObject Spawn(TextBoxData boxData)
	{
		PrefabType prefabType = boxData.DataPrefabType;

		if (prefabDict.TryGetValue(prefabType, out var prefabAndPosition))
		{
			return Instantiate(prefabAndPosition.prefab, prefabAndPosition.spawnPosition, Quaternion.identity);
		}

		return null;
	}
}
