using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] protected GameObject[] barrel;
    protected ParticleSystem[] particle;
    protected AudioSource shotSound;

    [SerializeField] protected float fireRate;
    protected float timerShoot = 0.0f;

    private void Start()
    {
        particle = GetComponentsInChildren<ParticleSystem>();
        shotSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Shoot();
    }

    public virtual void Shoot(){}
}
