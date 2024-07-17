using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
	private static readonly string FirstPlay = "FirstPlay"; //название объекта для сохранения
	private static readonly string MusicPref = "MusicPref"; //название объекта для сохранения
	private static readonly string SoundEffectsPref = "SoundEffectsPref";
	private int firstPlayInt;
	public Slider musicSlider, soundEffectsSlider; //слайдер звука
	private float musicFloat, soundEffectsFloat; //значение уровня звука
	public AudioSource musicAudio; //фоновая музыка
	public AudioSource[] soundEffectsAudio; //для эффектов

	void Start()
	{
		firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
		if (firstPlayInt == 0)
		{
			musicFloat = 0.25f; //уровень звука по умолчанию
			soundEffectsFloat = 0.75f;
			musicSlider.value = musicFloat;
			soundEffectsSlider.value = soundEffectsFloat;
			PlayerPrefs.SetFloat(MusicPref, musicFloat); //уровень по умолчанию
			PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
			PlayerPrefs.SetInt(FirstPlay, -1);
		}
		else
		{
			musicFloat = PlayerPrefs.GetFloat(MusicPref);
			musicSlider.value = musicFloat;
			soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
			soundEffectsSlider.value = soundEffectsFloat;
		}
	}

	public void SaveSoundSettings()
	{
		PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
		PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
	}

	private void OnApplicationFocus(bool inFocus) //сохранение при потере фокуса
	{
		if (!inFocus)
		{
			SaveSoundSettings();
		}
	}

	public void UpdateSound()
	{
		musicAudio.volume = musicSlider.value; //звук музыки - значение слайдера
		for (int i = 0; i < soundEffectsAudio.Length; i++)
		{
			soundEffectsAudio[i].volume = soundEffectsSlider.value;
		}
	}
}
