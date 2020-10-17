using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Transform target;
    private float distance = 7.3f;
    private float height = 2.5f;

    public float height_Dumping = 3.25f;
    public float rotation_Dumping = 0.27f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float wanted_Rotaion_Angle = target.eulerAngles.y;
        float wanted_Height = target.position.y + height;

        float current_Rotaion_Angle = transform.eulerAngles.y;
        float current_Height = transform.position.y;

        current_Rotaion_Angle = Mathf.LerpAngle(current_Rotaion_Angle, wanted_Rotaion_Angle, rotation_Dumping * Time.deltaTime);

        current_Height = Mathf.Lerp(current_Height, wanted_Height, Time.deltaTime);

        Quaternion current_Rotation = Quaternion.Euler(0f, current_Rotaion_Angle, 0f);

        transform.position = target.position;
        transform.position -= current_Rotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, current_Height, transform.position.z);
    }
}
