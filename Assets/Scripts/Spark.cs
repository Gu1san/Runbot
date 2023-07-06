using UnityEngine;

public class Spark : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }
}
