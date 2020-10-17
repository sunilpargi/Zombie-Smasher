using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : BaseController
{
    private Rigidbody myBody;

    public Transform bullet_StartPoint;
    public GameObject bullet_Prefab;
    public ParticleSystem shootFX;

    public Animator shootSLiderAnim;

    [HideInInspector]
    public bool canShoot;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        GameObject.Find("ShootBox").GetComponent<Button>().onClick.AddListener(ShootingControl);
       // shootSLiderAnim = GameObject.Find("FireBar").GetComponent<Animator>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovementWithKeyboard();
        ChangeRotation();   
    }

    private void FixedUpdate()
    {

        Movetank();
    }
    void Movetank()
    {
        myBody.MovePosition (myBody.position + speed  * Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move_Left();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move_Right();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            move_Fast();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move_Slow();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            move_Straight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            move_Straight();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            move_Normal();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            move_Normal();
        }

    }

    void ChangeRotation()
    {
        if(speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime);
        }

        else if(speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime);
        }
    }

    public void ShootingControl()
    {
     if(Time.timeScale != 0)
        {
            if (canShoot)
            {
                Debug.Log("Clicked");
                GameObject bullet = Instantiate(bullet_Prefab, bullet_StartPoint.position, Quaternion.identity);

                bullet.GetComponent<Bullet>().Move(2000f);
                shootFX.Play();

                canShoot = false;
                shootSLiderAnim.Play("FadeBar");
            }
        }
        
    }
}
