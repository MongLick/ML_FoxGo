using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	[Header("AudioSource")]
	[SerializeField] AudioSource bgmSource;
	public float BGMVolme { get { return bgmSource.volume; } set { bgmSource.volume = value; } }
	[SerializeField] AudioSource sfxSource;
	public float SFXVolme { get { return sfxSource.volume; } set { sfxSource.volume = value; } }

	[Header("SoundClips")]
	[Header("BGM")]
	[SerializeField] AudioClip titleClip;
	public AudioClip TitleClip { get { return titleClip; } set { titleClip = value; } }
	[SerializeField] AudioClip gameClip;
	public AudioClip GameClip { get { return gameClip; } set { gameClip = value; } }
	[SerializeField] AudioClip battleClip;
	public AudioClip BattleClip { get { return battleClip; } set { battleClip = value; } }

	[Header("SFX")]
	[SerializeField] AudioClip uiButtonClip;
	public AudioClip UiButtonClip { get { return uiButtonClip; } set { uiButtonClip = value; } }

	public void PlayBGM(AudioClip clip)
	{
		if (bgmSource.isPlaying)
		{
			bgmSource.Stop();
		}
		bgmSource.clip = clip;
		bgmSource.Play();
	}

	public void PlaySFX(AudioClip clip)
	{
		sfxSource.PlayOneShot(clip);
	}
}
