using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickController : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;

    void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();

    void Update()
    {
        //using the nav mesh and collisions to find the the position where the mouse is clicked and the player will go to said position
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
            _navMeshAgent.SetDestination(hitInfo.point);
    }
}
