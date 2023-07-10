using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject playerObj;
    [SerializeField]
    private float rotationSpeed;
    public float fireRate;
    private float timerShoot = 1.0f;
    public Transform gun;
    [SerializeField]
    private GameObject bullet;
    public ParticleSystem particle;
    public AudioSource shot;
    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    
    void Update()
    {
        Shoot();
        Rotation();
    }

    void Shoot()
    {
        if (Time.time > timerShoot)
        {
            particle.Play();
            shot.Play();
            Instantiate(bullet, gun.position, gun.rotation * Quaternion.Euler(180.0f, 0, 0));
            timerShoot = Time.time + fireRate;
        }
    }
    void Rotation()
    {
        Vector3 position = new Vector3(playerObj.transform.position.x, transform.position.y, playerObj.transform.position.z);
        Quaternion rot = Quaternion.LookRotation(position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot * Quaternion.Euler(0,-90.0f,0), Time.deltaTime * rotationSpeed);
    }
}
