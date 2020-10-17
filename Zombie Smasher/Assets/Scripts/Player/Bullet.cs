using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody myBody;


    public void Move(float speed)
    {
        myBody.AddForce(transform.forward.normalized * speed);
        Invoke("DeactivateBullet", 5f);
    }

    void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Obstacle" || target.gameObject.tag == "Zombie")
        {
         
            gameObject.SetActive(false);
        }
    }
}
