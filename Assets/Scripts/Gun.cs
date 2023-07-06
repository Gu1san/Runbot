using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    [Header("Settings")]
    public float fireRate;
    private float timerShoot = 0.0f;
    [SerializeField]
    private GameObject[] barrel;
    [SerializeField]
    private bool automatic;
    [SerializeField]
    private bool dual;
    private ParticleSystem[] particle;
    private AudioSource shotSound;

    private void Start()
    {
        particle = GetComponentsInChildren<ParticleSystem>();
        shotSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(UIManager.instance != null)
        {
            if (!UIManager.instance.isPaused)
            {
                if (automatic)
                {
                    if (Input.GetMouseButton(0) && (Time.time > timerShoot))
                    {
                        Shoot();
                    }
                }
                else if (!automatic)
                {
                    if (!GameController.instance.doubleGun)
                    {
                        if (Input.GetMouseButtonDown(0) && (Time.time > timerShoot))
                        {
                            Shoot();
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(1) && (Time.time > timerShoot))
                        {
                            Shoot();
                        }
                    }
                }
            }
        }
    }

    void Shoot()
    {
        if (!GameController.instance.buffFireRate)
        {
            timerShoot = Time.time + fireRate;
        }
        else
        {
            timerShoot = Time.time + (fireRate * 0.8f);
        }
        Instantiate(bullet, barrel[0].transform.position, transform.rotation * Quaternion.Euler(180.0f, 0, 0));
        particle[0].Play();
        shotSound.Play();
        if (dual)
        {
            Invoke("SecondShot", fireRate / 2);
        }
    }

    void SecondShot()
    {
        Instantiate(bullet, barrel[1].transform.position, transform.rotation * Quaternion.Euler(180.0f, 0, 0));
        particle[1].Play();
        shotSound.Play();
    }
}
