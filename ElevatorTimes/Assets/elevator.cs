using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upupup();//improve-> no limits to character
        
    }
    void upupup()
    {
        if (Input.GetKeyDown("u") )
        {
            //Physics.gravity = new Vector3(0, 12, 0);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 200);

        }
        if (Input.GetKeyDown("i"))
        {

            GetComponent<Rigidbody>().AddForce(Vector3.down * 200);

        }

    }
    
}
