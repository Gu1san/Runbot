using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private new BoxCollider collider;
    public GameObject pointLight;
    
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }
    public void Open()
    {
        pointLight.SetActive(true);
        collider.enabled = true;
    }    
}
