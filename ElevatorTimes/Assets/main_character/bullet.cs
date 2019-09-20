using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    int cnt =0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 1f);

 //       shoot();
    }
    void shoot()
    {
        if (Input.GetKeyDown("e"))
        {
            if (cnt < 6)
            {
                
                transform.localPosition = new Vector3(1, 1 / 100, 4 / 10);
                GetComponent<Rigidbody>().AddForce(Vector3.right * 1000000);
                if (cnt != 0)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.left * 1000000);
                }
                cnt++;
            }
            
                
            

        }
        if (cnt == 6)
        {
            transform.localPosition = new Vector3(100,100,100);
            GetComponent<Rigidbody>().AddForce(Vector3.right * 1000000);

        }



    }

}
