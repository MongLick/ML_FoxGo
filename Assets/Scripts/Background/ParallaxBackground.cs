using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Transform target;

	[Header("Vector")]
	[SerializeField] Vector3 moveDirection;

	[Header("Specs")]
	[SerializeField] float moveSpeed;	
	[SerializeField] float scrollAmount;

	private void Update()
	{
		if (Manager.Game.IsArrival)
		{
			return;
		}

		transform.position += moveDirection * moveSpeed * Time.deltaTime;

		if (transform.position.x <= -scrollAmount)
		{
			transform.position = target.position - moveDirection * scrollAmount;
		}
	}
}
