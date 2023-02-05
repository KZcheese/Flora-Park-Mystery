using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venus : MonoBehaviour
{

    public NPC venusNPC;
    public GameManager gameManager;

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
        
    }
}
