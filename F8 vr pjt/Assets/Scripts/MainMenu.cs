using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // Quando Clicar em play, ir para a scene 1
        SceneManager.LoadScene(1);
        //Acha o AudioManager e toca ButtonPress
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    public void QuitGame()
    {
        // Application.Quit não acontece no editor
        Debug.Log("Quit");
        // Quando clicar em quit, o jogo fecha
        Application.Quit();
    }

}
