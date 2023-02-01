using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public string[] dialogue,
                    dialogue2;

    public TextMeshProUGUI dialogueTextBox;
    public GameObject dialoguePanel;

    bool corrutineWorking,
         playerInside,
         secondDialogue;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    IEnumerator DialogueCor(string text)
    {
        dialoguePanel.SetActive(true);
        dialogueTextBox.text = "";
        corrutineWorking = true;

        for (int i = 0; i < text.Length; i++)
        {
            dialogueTextBox.text += text[i];
            yield return new WaitForSeconds(0.01f);
        }

        corrutineWorking = false;
        index++;
    }

    private void Action()
    {
        if (Input.GetButtonDown("Fire1") && playerInside)
        {
            //Que se termine de mostrar el texto si pincho mientras se despliega
            if (corrutineWorking)
            {
                StopAllCoroutines();
                dialogueTextBox.text = dialogue[index];
                corrutineWorking = false;
                index++;
            }
            else
            {
                //Comience a mostrarse el siguiente texto
                if (!secondDialogue && index < dialogue.Length)
                {
                    StartCoroutine(DialogueCor(dialogue[index]));
                }
                else if (secondDialogue && index < dialogue2.Length)
                {
                    StartCoroutine(DialogueCor(dialogue2[index]));
                }
                //Aquí si no hay más texto se  reinicia todo
                else
                {
                    Reset();
                }
            }
        }
    }

    private void Reset()
    {
        dialoguePanel.SetActive(false);
        dialogueTextBox.text = "";
        StopAllCoroutines();
        corrutineWorking = false;
        secondDialogue = true;
        index = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            Reset();
        }
    }
}
