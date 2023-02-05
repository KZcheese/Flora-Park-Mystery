using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venus : MonoBehaviour
{

    public NPC venusNPC;
    public GameManager gameManager;
    public GameObject panel;

    public bool finishedAct1 = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.allPlantsChecked == true)
        {
            //Move to ending convo once everyone has been talked to.
            venusNPC.activeAct = 1;
        }

        if(gameManager.venusTwoChecked == true)
        {
            venusNPC.activeAct = 2;
            venusNPC.trigger.StartDialogue(2);
        }

        if(gameManager.venusThreeChecked == true)
        {
            venusNPC.activeAct = 3;
            //venusNPC.trigger.StartDialogue(3);
        }
        
    }

    public void ending()
    {
        if(venusNPC.activeAct == 2)
        {

        }
    }
}
