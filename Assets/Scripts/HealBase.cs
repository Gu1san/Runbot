using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBase : MonoBehaviour
{
    public int HPRegen;
    private bool healed;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !UIManager.instance.isPaused && !healed)
            {
                Debug.Log("Curou");
                GameController.instance.OnHeal(HPRegen);
                healed = true;
            }

            else if(Input.GetKeyDown(KeyCode.E) && !UIManager.instance.isPaused && healed)
            {
                Debug.Log("Já curou fi");
            }
        }
    }
}
