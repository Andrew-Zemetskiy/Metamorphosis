using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeLevel : MonoBehaviour
{
    public float additionalVolume;
    public bool needToAddVolume;
    void Start()
    {
        GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat * (needToAddVolume ? additionalVolume : 1);
    }
}
