using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill System/Skill")]
public class Skill : ScriptableObject
{
	public Sprite icon;
	public string skillName;
	[TextArea]
	public string description;

	public GameObject prefab;
	public float damage;

	public void Activate(GameObject monster)
	{
		GameObject instance = Instantiate(prefab, monster.transform.position, Quaternion.identity);
	}
}
