using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    public int currentHP;
    public int totalHP;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private bool isRanged;
    public float fireRate;
    private float timerShoot = 1.0f;

    [Header("Components")]
    [SerializeField]
    NavMeshAgent navMesh;
    public GameObject[] loot;
    private GameObject playerObj;
    public Transform[] gun;
    [SerializeField]
    private GameObject bullet;
    private ParticleSystem particle;
    public AudioSource shot;
    [SerializeField] GameObject explosion;
    [SerializeField] Transform explosionPoint;

    private SpawnManager spawner;
    private float iFrame = 0.0f;
    void Start()
    {
        currentHP = totalHP;
        navMesh = GetComponent<NavMeshAgent>();
        playerObj = GameObject.Find("Player");
        spawner = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        particle = GetComponentInChildren<ParticleSystem>();
    }
    
    void Update()
    {
        if(playerObj != null)
        {
            Walk();
            Rotation();
            if (isRanged && navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                Shoot();
            }
        }
    }

    void Walk()
    {
        navMesh.SetDestination(playerObj.transform.position);
    }

    void Shoot()
    {
        if(Time.time > timerShoot)
        {
            particle.Play();
            shot.Play();
            for(int i = 0; i<gun.Length; i++){
                Instantiate(bullet, gun[i].position, gun[i].rotation * Quaternion.Euler(180.0f, 0, 0));
            }
            timerShoot = Time.time + fireRate;
        }
    }

    void Rotation()
    {
        Quaternion rot = Quaternion.LookRotation(playerObj.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
    }

    public void Drop(GameObject item)
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

    public void TakeDamage(int dmg)
    {
        if(Time.time > iFrame)
        {
            if (currentHP > 0)
            {
                currentHP -= dmg;
            }
            else
            {
                Die();
                Drop(loot[0]);
            }
        }           
    }

    private void Die()
    {
        spawner.enemiesKilled++;
        if (spawner.enemiesKilled == spawner.enemySpawnAmount)
        {
            if(spawner.waveNumber == spawner.totalWaves)
            {
                Drop(loot[1]);
            }
            spawner.NextWave();
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(explosion, explosionPoint.position, Quaternion.identity);
    }
}
