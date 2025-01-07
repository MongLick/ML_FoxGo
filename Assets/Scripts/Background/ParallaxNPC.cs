using UnityEngine;

public class ParallaxNPC : MonoBehaviour
{
	[Header("Vector")]
	[SerializeField] Vector3 moveDirection;

	[Header("Specs")]
	[SerializeField] float moveSpeed;
	[SerializeField] float scrollAmount;
	[SerializeField] bool isCompletion;

	private void OnEnable()
	{
		isCompletion = false;
	}

	private void Update()
	{
		if (Manager.Game.IsArrival)
		{
			return;
		}

		if (transform.position.x <= 0 && !isCompletion)
		{
			Manager.Game.IsArrival = true;
			isCompletion = true;
		}
		else
		{
			transform.position += moveDirection * moveSpeed * Time.deltaTime;
			if (transform.position.x <= scrollAmount)
			{
				Destroy(gameObject);
			}
		}
	}
}
