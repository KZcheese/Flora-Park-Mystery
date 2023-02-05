using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will hold separate data for each npc or button of the scene and transfer all messages to the dialogue box to dislay to the screen when needed.
public class DialogueTrigger : MonoBehaviour
{
    public Act[] act;
    public GameObject panel;
    public GameObject startButton;
    //public Message[] messages;
    //public Actor[] actors;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(int actID)
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(actID, act);

    }

    public void StartDialogueButton(int actID)
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(actID, act);
        if (panel.activeInHierarchy && startButton.activeInHierarchy && DialogueManager.isActive)
        {
            startButton.SetActive(false);
            Invoke("RemovePanelAndStartButton", 5f);
            
        }
    }

    public void RemovePanelAndStartButton()
    {
        panel.SetActive(false);
        
    }
}

[System.Serializable]
public class Act
{
    public int atcID;
    public Message[] messages;
    public Actor[] actors;
}

[System.Serializable]
public class Message {
   // public int actID;
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    //public Sprite sprite;
}



