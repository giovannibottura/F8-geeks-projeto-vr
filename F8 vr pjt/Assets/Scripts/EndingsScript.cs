using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EndingsScript : MonoBehaviour
{

    //Volta para o menu e toca o som
    public void VoltarInicio()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }
}
