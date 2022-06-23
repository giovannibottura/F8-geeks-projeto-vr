using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        // O volume do audiomixer é igual ao do slider
        audioMixer.SetFloat("volume", volume);
    } 

    public void Settings()
    {
        //Acha AudioManager e toca ButtonPress
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

}
