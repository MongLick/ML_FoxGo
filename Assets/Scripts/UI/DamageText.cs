using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] PooledObject pooledObject;
	[SerializeField] TMP_Text damageText;

	[Header("Specs")]
	[SerializeField] float fadeDuration;

	public void Initialize(int damageAmount)
	{
		damageText.text = damageAmount.ToString();

		StartCoroutine(FadeText());
	}

	private IEnumerator FadeText()
	{
		float fadeTime = 0f;
		Color startColor = damageText.color;
		while (fadeTime < fadeDuration)
		{
			float alpha = Mathf.Lerp(1, 0, fadeTime / fadeDuration);
			damageText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			fadeTime += Time.deltaTime;
			yield return null;
		}

		pooledObject.Pool.ReturnPool(pooledObject);
	}
}
