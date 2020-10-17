using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
  public void ResetShooting()
    {
        playerController.canShoot = true;
        anim.Play("Idle");
    }

     void CameraStartgame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
