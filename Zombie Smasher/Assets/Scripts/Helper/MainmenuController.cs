using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuController : MonoBehaviour
{
    public Animator mainCam;
public void Playgame()
    {
        mainCam.Play("Slide");
    }
}
