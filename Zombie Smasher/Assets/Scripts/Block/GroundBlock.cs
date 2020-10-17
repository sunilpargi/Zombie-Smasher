using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    public Transform otherBlock;
    public float halfLength = 100f;
    private Transform player;
    private float endOffSet = 10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Moveground();
    }

    private void Moveground()
    {
        if(transform.position.z + halfLength < player.position.z - endOffSet)
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, otherBlock.position.z + 2 * halfLength);
        }
    }
}
