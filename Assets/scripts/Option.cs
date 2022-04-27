using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Option : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup Mixer;
   private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ChangeVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("Sound", Mathf.Lerp(-80, 0, volume));
    }
}
