using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Quando Clicar em play, ir para a scene 1 (O 1 level)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Application.Quit não acontece no editor
        Debug.Log("Quit");
        // Quando clicar em quit, o jogo fecha
        Application.Quit();
    }

}
