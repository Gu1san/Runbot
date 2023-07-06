using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;
    private GameObject player;
    Vector3 dir;
    [SerializeField]
    private int value;
    [SerializeField]
    Player playerScript;

    private void Start()
    {
        player = GameObject.Find("Player");
        value = Random.Range(1, 3);
        
    }

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (player.transform.hasChanged)
        {
            dir = (player.transform.position - transform.position).normalized;
        }        
        transform.Translate(dir * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerScript = other.GetComponent<Player>();
            playerScript.CatchCoin(value);
        }
    }
}
