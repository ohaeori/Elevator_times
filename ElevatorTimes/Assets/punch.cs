using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        push();//improve-> not change position but make movement
    }

    void push()
    {
        int a = 0;

        if (Input.GetKeyDown("q"))
        {

            transform.Translate(Vector3.right * 4 * Time.smoothDeltaTime * 10, Space.World);

        }
        if (Input.GetKeyUp("q"))
        {
            transform.Translate(Vector3.left * 4 * Time.smoothDeltaTime * 10, Space.World); 

        }

    }
}
