using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;

    public float x_Speed = 8f, z_speed = 15f;

    public float accelerated = 15f, deaccelerated = 10f;

    protected float rotationSpeed = 10f;
    protected float maxAngle = 15f;

    public float low_Sound_Pitch, normal_Sound_Pitch, high_Sound_Pitch;

    private AudioSource soundManager;
    public AudioClip engine_On_Sound, engine_Off_Sound;
    private bool is_Slow;
    void Awake()
    {
        soundManager = GetComponent<AudioSource>();
        speed = new Vector3(0, 0, z_speed);
    }

    protected void move_Left()
    {
        speed = new Vector3(-x_Speed, 0, speed.z);
    }
    protected void move_Right()
    {
        speed = new Vector3(x_Speed, 0, speed.z);
    }
    protected void move_Straight()
    {
        speed = new Vector3(0, 0, speed.z);
    }
   
    protected void move_Slow()
    {
        if (!is_Slow)
        {
            is_Slow = true;
            soundManager.Stop();
            soundManager.clip = engine_Off_Sound;
            soundManager.volume = 0.5f;
            soundManager.Play();
        }

        speed = new Vector3(speed.x, 0, deaccelerated);
    }
    protected void move_Normal()
    {
        if (is_Slow)
        {
            is_Slow = false;
            soundManager.Stop();
            soundManager.clip = engine_On_Sound;
            soundManager.volume = 0.3f;
            soundManager.Play();
        }

        speed = new Vector3(speed.x, 0, z_speed);
    }
    protected void move_Fast()
    {
        speed = new Vector3(speed.x, 0, accelerated);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
