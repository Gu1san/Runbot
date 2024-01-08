using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGiver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<Shield>(true).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
