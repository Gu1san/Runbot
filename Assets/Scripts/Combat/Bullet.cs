using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Enemy enemy;
    private Player player;
    public int damage;
    [SerializeField]
    private bool enemyBullet;
    public GameObject particle;

    private void OnEnable()
    {
        Invoke("DisableBullet", 3);
    }


    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!enemyBullet)
        {
            if (other.CompareTag("Enemy"))
            {
                enemy = other.GetComponent<Enemy>();
                enemy?.TakeDamage(damage);
                //gameObject.SetActive(false);
                DisableBullet();
                return;
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                player = other.GetComponent<Player>();
                player.OnHit();
                //gameObject.SetActive(false);
                DisableBullet();
                return;
            }
        }
    }

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (!gameObject.scene.isLoaded) return;
        CancelInvoke();
        Instantiate(particle, transform.position, transform.rotation);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        PoolAPI.instance.Pool.Release(gameObject);
    }
}
