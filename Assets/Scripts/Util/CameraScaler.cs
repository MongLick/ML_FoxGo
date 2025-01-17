using UnityEngine;

public class CameraScaler : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Camera mainCamera;

	[Header("Specs")]
	[SerializeField] float targetWidth;
	[SerializeField] float targetHeight;
	[SerializeField] float zoomFactor;

	private void Start()
	{
		float targetAspect = targetWidth / targetHeight;

		float windowAspect = (float)Screen.width / (float)Screen.height;

		if (windowAspect > targetAspect)
		{
			mainCamera.orthographicSize = targetHeight / zoomFactor;
		}
		else
		{
			float scale = targetAspect / windowAspect;
			mainCamera.orthographicSize = (targetHeight / zoomFactor) * scale;
		}
	}
}
