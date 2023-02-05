using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    public static bool playerDetected = false;
    public int activeAct = 0;
    Act[] acts;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision detected" + collision.gameObject.name);
    //    if(collision.gameObject.CompareTag("Player") == true)
    //    {
    //        Debug.Log("Player detected");
    //        trigger.StartDialogue();
    //    }

    //}

    public void Start()
    {
        acts = trigger.act;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == this.name && playerDetected == true)
                {
                    trigger.StartDialogue(activeAct);
                    
                    if(activeAct < acts.Length - 1)
                    {
                        activeAct++;
                    }
                    else
                    {
                        activeAct = 0;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected" + other.gameObject.name);
        if (other.gameObject.CompareTag("Player") == true){
            Debug.Log("Player detected");
            //trigger.StartDialogue();

            //Trying mouse
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Left: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("Player Left");
            //trigger.StartDialogue();

            //Trying mouse
            playerDetected = false;
        }

    }
}
