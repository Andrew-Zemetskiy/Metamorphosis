using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
	private static readonly string MusicPref = "MusicPref";
	private static readonly string SoundEffectsPref = "SoundEffectsPref";
	public float musicFloat, soundEffectsFloat;
	public AudioSource musicAudio;
	public AudioSource[] soundEffectsAudio;

	private void Awake()
	{
		LevelSoundSettings();
	}

	private void LevelSoundSettings()
	{
		musicFloat = PlayerPrefs.GetFloat(MusicPref);
		soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

		musicAudio.volume = musicFloat;
		for (int i = 0; i < soundEffectsAudio.Length; i++)
		{
			soundEffectsAudio[i].volume = soundEffectsFloat;
		}
	}
	public float EffectsVolume()
	{
		return PlayerPrefs.GetFloat(SoundEffectsPref);
	}
}
