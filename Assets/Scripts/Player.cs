using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    [SerializeField]
    private float recoveryTime;
    private float timer = 0.0f;
    public float shieldCoolDown;
    public bool shieldOn;


    [Header("Rotation")]
    [SerializeField]
    private float rotationSpeed;
    private RaycastHit hit;
    private Ray ray;
    public LayerMask mask;
    private Vector3 currentLookTarget = Vector3.zero;
    [SerializeField]
    private float distance;

    [Header("Components")]
    public Rigidbody rig;
    [SerializeField]
    Portal portal;
    private ParticleSystem particles;
    public GameObject[] guns;
    public GameObject shield;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        particles = GetComponent<ParticleSystem>();
        if (!GameController.instance.doubleGun)
        {
            guns[GameController.instance.equipedGun].SetActive(true);
        }
        else
        {
            guns[0].SetActive(true);
            guns[1].SetActive(true);
        }
        if (GameController.instance.shieldAvaliable)
        {
            shield.SetActive(true);
        }
    }

    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(inputX, 0, inputZ);

        rig.velocity = dir * speed;
    }
    void Rotation()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out hit, distance, mask, QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
                Vector3 position = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                Quaternion rot = Quaternion.LookRotation(position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
            }
        }
    }
    public void OnHit()
    {
        if (!shieldOn)
        {
            bool includeChildren = false;
            if (Time.time > timer)
            {
                particles.Play(includeChildren);
                GameController.instance.OnHit();
                timer = Time.time + recoveryTime;
                if (GameController.instance.playerHealth <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if(GameController.instance.shieldAvaliable && shieldOn)
        {
            shieldOn = false;
            shield.SetActive(false);
            StartCoroutine(ReturnShield());
        }
    }
    public void CatchCoin(int coinValue)
    {
        GameController.instance.coins += coinValue;
        UIManager.instance.coinsCount.text = GameController.instance.coins.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnHit();
        }

        if (other.CompareTag("Portal"))
        {
            Debug.Log("Colidiu com o portal");
            GameController.instance.NextLevel();
        }

        if (other.CompareTag("Loot"))
        {
            Destroy(other.gameObject);
            Debug.Log("Novo item coletado!");
            portal.Open();
            Debug.Log("Próxima fase");
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Shop box = other.GetComponent<Shop>();
            if (Input.GetKeyDown(KeyCode.E) && UIManager.instance.isPaused == false)
            {
                box.ShowShop();
            }
        }

        if (other.CompareTag("Enemy"))
        {
            OnHit();
        }
    }

    IEnumerator ReturnShield()
    {
        yield return new WaitForSeconds(shieldCoolDown);
        shieldOn = true;
        shield.SetActive(true);
    }
}
