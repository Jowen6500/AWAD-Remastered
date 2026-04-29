using UnityEngine;
using UnityEngine.Audio;

public class settingsmenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("Vol", volume);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
