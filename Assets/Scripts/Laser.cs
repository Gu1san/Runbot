using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Laser : MonoBehaviour
{
    [SerializeField] VisualEffect laser;
    public float fireRate = 4;
    private float timerShoot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && Time.time > timerShoot)
        {
            Debug.Log("Play");
            timerShoot = Time.time + fireRate;
            laser.Play();
        }
    }
}
