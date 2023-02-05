using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool talkedFigTree = false;
    public bool talkedCoffee = false;
    public bool talkedPoppy = false;
    public bool talkedDand = false;
    public bool talkedCops = false;
    public bool talkedGrass = false;

    public bool allPlantsChecked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(talkedCoffee && talkedCops && talkedDand && talkedFigTree && talkedGrass && talkedPoppy)
        {
            allPlantsChecked = true;
        }
    }




}
