﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject bloodPrefab;
    private float speed = 1f;

    private Rigidbody myBody;

    private bool isAlive;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.velocity = new Vector3(0f, 0f, -speed);
        isAlive = true;
        speed = UnityEngine.Random.Range(1f, 5f );
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            myBody.velocity = new Vector3(0f, 0f, -speed);
        }
      
        if (transform.position.z < -10f)
        {
            gameObject.SetActive(false);
        }
    }

    void Die()
    {
        isAlive = false;
        myBody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");

        transform.rotation = Quaternion.Euler(90f, 0, 0);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision target)
    {
     if(target.gameObject.tag == "Player" || target.gameObject.tag == "Bullet")
        {
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);

            Invoke("DeactivateGameObject", 3f);

            Die();
        } 
    }
}
