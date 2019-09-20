using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rigid;

    public float JumpPower;


    public GameObject Bullet;
    public Transform FirePos;

    int Shoot_cnt = 0;

    bool IsJumping;
    bool IsDoubleJumping;
    int JumpCnt;
    bool IsGravity;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        IsJumping = false;
        IsDoubleJumping = false;
        JumpCnt = 0;
        IsGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveObject();//improve-> act only press arrow
        jump();
        //rotationObject();//improve-> not change position but make movement
        //turn();
        shoot();
        upupup();
      
       
    }
    void upupup()
    {
        if (Input.GetKeyDown("u"))
            rigid.useGravity = false;
        if (Input.GetKeyDown("i"))
            rigid.useGravity = true;
    }
    void shoot()
    {        
        if (Input.GetKeyDown("e")&&Shoot_cnt<5)//shoot the bullet, limit 5
        {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Shoot_cnt++;
        }
        if (Input.GetKeyDown("r"))//reload
            Shoot_cnt = 0;
    }
    void turn()
    {

     
    }
    void moveObject()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right *4*  Time.smoothDeltaTime * keyHorizontal, Space.World);
        transform.Translate(Vector3.forward  *4* Time.smoothDeltaTime * keyVertical, Space.World);
    }
    void jump()
    {
        if (Input.GetKeyDown("j"))
            IsDoubleJumping = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //바닥에 있으면 점프를 실행
            if (!IsJumping)
            {
                if(!(IsDoubleJumping && JumpCnt == 0))//check double jump
                    IsJumping = true;
                if (JumpCnt==1)
                    rotationObject();
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                JumpCnt++;
            }

            //공중에 떠있는 상태이면 점프하지 못하도록 리턴
            else
            {
                //print("점프 불가능 !");
                return;
            }
        }


    
    }
    private void OnCollisionEnter(Collision collision)
    {
        //바닥에 닿으면
        if (collision.gameObject.CompareTag("Ground"))
        {
            //점프가 가능한 상태로 만듦
            IsJumping = false;
            JumpCnt = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    
    void rotationObject()
    {
        int a = 0;
        if (Input.GetKeyDown("space"))
            transform.rotation = Quaternion.Euler(179, 0, 0);
        if (Input.GetKeyDown("r"))
        {
            a = a + 50;
            transform.rotation = Quaternion.Euler(0, a, 0);
        }
        if (Input.GetKeyUp("r"))
        {
            a = a - 50;
            transform.rotation = Quaternion.Euler(0, a, 0);
        }

    }
}
