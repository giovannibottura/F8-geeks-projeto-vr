using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    private int index;


    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
        ClickForLine();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Digita cada caractere 1 por 1 criando fluidez
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            FindObjectOfType<AudioManager>().Play("Digitar");
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //Ir para o proximo texto
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        //Quando acabar todos os textos, ir para o próximo level (No caso Level1)
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    void ClickForLine()
    {
        //Se clicar e o texto terminou ir para o proximo texto, se não terminou o texto, terminar o texto
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

}
