using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UI_Settings : MonoBehaviour
{
    public AudioMixer am;
    private bool isFullScreen;
    public void FullScreenToggle()
    {
        isFullScreen = ! isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

}
