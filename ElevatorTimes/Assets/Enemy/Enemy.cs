using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;




    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        


    }

    // Update is called once per frame
    void Update()
    {
        chace();
        


    
    }
    void chace()
    {
        if (Input.GetKeyDown("c"))
        {
            if (nav.destination != target.transform.position)
            {
                nav.SetDestination(target.transform.position);
            }
            else
            {
                nav.SetDestination(transform.position);
            }
        }
    }
}
