using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioSource audio_src1;
    public void PlaySoundButton1()
    {
        // Toca o audio 1
        audio_src1.Play();
    }
}
