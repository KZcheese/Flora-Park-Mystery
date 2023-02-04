using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will hold separate data for each npc or button of the scene and transfer all messages to the dialogue box to dislay to the screen when needed.
public class DialogueTrigger : MonoBehaviour
{

    public Message[] messages;
    public Actor[] actors;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}



[System.Serializable]
public class Message {
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    //public Sprite sprite;
}



