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
    void Start()
    {
        Destroy(gameObject, 3.0f);       
    }

    
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * -1 * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!enemyBullet)
        {
            if (other.CompareTag("Enemy"))
            {
                enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                Instantiate(particle, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                player = other.GetComponent<Player>();
                player.OnHit();
                Instantiate(particle, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

}
