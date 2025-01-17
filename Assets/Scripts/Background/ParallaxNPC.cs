using UnityEngine;

public class ParallaxNPC : MonoBehaviour
{
	[Header("Vector")]
	[SerializeField] Vector3 moveDirection;

	[Header("Specs")]
	[SerializeField] float moveSpeed;
	[SerializeField] float scrollAmount;
	[SerializeField] float xPosition;
	[SerializeField] bool isCompletion;
	public bool IsCompletion { get { return isCompletion; } }

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

		if (transform.position.x <= xPosition && !isCompletion)
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
