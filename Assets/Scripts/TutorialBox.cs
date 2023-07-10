using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    [SerializeField] float minLifetime = 3;
    public bool hasShown = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > minLifetime)
            {

            }
        }
    }
}
