using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public GameObject panel;
    public Venus venusNPC;

    //Tring the act class based on the currenttMessages and currentActors methods previously set up
    Act[] allActs;
    int activeActID = 0;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;


    public void OpenDialogue(int actID, Act[] acts)
    {
        activeActID = actID;
        allActs = acts;
        currentMessages = allActs[activeActID].messages;
        currentActors = allActs[activeActID].actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started Conversation! Loaded Messages: " + allActs[activeActID].messages.Length);
        DisplayMessage();

        //Message Animations
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    //Original Method using messages and actors
    //public void OpenDialogue(Message[] messages, Actor[] actors)
    //{
    //    currentMessages = messages;
    //    currentActors = actors;
    //    activeMessage = 0;
    //    isActive = true;

    //    Debug.Log("Started Conversation! Loaded Messages: " + messages.Length);
    //    DisplayMessage();

    //    //Message Animations
    //    backgroundBox.LeanScale(Vector3.one, 0.5f);
    //}

    void DisplayMessage()
    {
        //If activemessage is 0 we will get first message of array
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        //Could add sprite to character dialogue

        AnimateTextColor();
    }

    public void NextMessage()
    {
        
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            activeMessage++;
        }
        else
        {
            Debug.Log("Conversation has ended.");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;

            //Ending
            if(venusNPC.venusNPC.activeAct == 1)
            {
                Invoke("MoveToVenusActTwo", 2f);
                //MoveToVenusActTwo();

            }

            if (venusNPC.venusNPC.activeAct == 2)
            {
                Invoke("MoveToVenusActThree", 2f);
                //MoveToVenusActTwo();

            }
        }
    }

    private void MoveToVenusActTwo()
    {
        venusNPC.venusNPC.activeAct = 2;
        panel.SetActive(true);
        venusNPC.venusNPC.trigger.StartDialogue(venusNPC.venusNPC.activeAct);
    }

    private void MoveToVenusActThree()
    {
        venusNPC.venusNPC.activeAct = 3;
        //panel.SetActive(true);
        venusNPC.venusNPC.trigger.StartDialogue(venusNPC.venusNPC.activeAct);
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        venusNPC = FindObjectOfType<Venus>();
    }

    // Update is called once per frame
    void Update()
    {
        //Trying with Space Button for now, could change to anything later
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }
}
