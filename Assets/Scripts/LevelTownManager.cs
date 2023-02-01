using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTownManager : MonoBehaviour
{

    public static LevelTownManager instance;
    public Dialogue dialogueBoy;

    public string[] newExitDialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void OpenChest()
    {
        dialogueBoy.dialogue = newExitDialogue;
        dialogueBoy.dialogue2 = newExitDialogue;

        //Coger la posición del npc y la vamos a mover a la derecha
        //dialogueBoy.transform.position = dialogueBoy.transform.position + dialogueBoy.transform.right;
        dialogueBoy.transform.position += dialogueBoy.transform.right;
    }
}
