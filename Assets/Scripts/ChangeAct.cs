using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAct : MonoBehaviour
{
    public NPC thisNPC;
    public NPC otherNPC;
    public int actReached;
    public int otherNpcActtSwitch;
    public bool changeDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeActBasedOnNPC();

    }

    private void ChangeActBasedOnNPC()
    {
        if (changeDone == false)
        {
            if (thisNPC.activeAct == actReached)
            {
                Debug.Log("ACT REACHED");
                Debug.Log("Before if statement, act switch: " + otherNpcActtSwitch + "actual act length" + (otherNPC.trigger.act.Length - 1));
                if (otherNpcActtSwitch <= otherNPC.trigger.act.Length - 1)
                {
                    Debug.Log("In the if statement, also length of other npc act length: " + (otherNPC.trigger.act.Length - 1));
                    otherNPC.activeAct = otherNpcActtSwitch;
                    changeDone = true;
                }

            }
        }
    }
}
