using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfetrTime : MonoBehaviour
{
    private float timer = 3f;
    void Start()
    {
        Invoke("DeactivategameObject", timer);
    }

    // Update is called once per frame
   void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
