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
                if (hit.transform.gameObject == this.gameObject && playerDetected == true && DialogueManager.isActive == false)
                {
                    trigger.StartDialogue(activeAct);
                    Debug.Log("This tag was clicked: " + this.tag);
                    Debug.Log("Hit tag was: " + hit.transform.tag);
                    //if (activeAct == 2)
                    //{
                    //    //trigger.StartDialogue(activeAct);
                    //}
                    //else
                    //{
                    //    //activeAct = 0;
                    //}

                    CheckPlants();
                    
                }
            }
        }
    }

    private void CheckPlants()
    {
        if (this.tag == "Coffee")
        {
            FindObjectOfType<GameManager>().talkedCoffee = true;
        }

        if (this.tag == "Dande")
        {
            FindObjectOfType<GameManager>().talkedDand = true;
        }

        if (this.tag == "Poppy")
        {
            FindObjectOfType<GameManager>().talkedPoppy = true;
        }

        if (this.tag == "Tree")
        {
            FindObjectOfType<GameManager>().talkedFigTree = true;
        }

        if (this.tag == "Cops")
        {
            FindObjectOfType<GameManager>().talkedCops = true;
        }

        if (this.tag == "Grass")
        {
            FindObjectOfType<GameManager>().talkedGrass = true;
        }

        if(this.tag == "Venus" && FindObjectOfType<GameManager>().allPlantsChecked == true)
        {
            FindObjectOfType<GameManager>().venusTwoChecked = true;
        }

        //if(this.tag == "Venus" && FindObjectOfType<GameManager>().venusTwoChecked == true)
        //{
        //    FindObjectOfType<GameManager>().venusThreeChecked = true;
        //}


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
