using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public Player player;
    public GameObject shopPanel;
    public Text[] equipText;
    public List<Item> itens;
    public bool[] boughtItens;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void ShowShop()
    {
        shopPanel.SetActive(true);
        UIManager.instance.Pause();
    }

    public void HideShop()
    {
        shopPanel.SetActive(false);
        UIManager.instance.Unpause();
    }
    public void ChangeGun(int id)
    {
        if (id == 0)
        {
            player.guns[1].SetActive(false);
            player.guns[id].SetActive(true);
            equipText[id].text = "Equiped";
            equipText[1].text = "Equip";
        }
        else if (id == 1)
        {
            player.guns[0].SetActive(false);
            player.guns[id].SetActive(true);
            equipText[id].text = "Equiped";
            equipText[0].text = "Equip";
        }
        GameController.instance.equipedGun = id;
    }

    public void Buy(Item item)
    {
        if (item.cost <= GameController.instance.coins)
        {
            GameController.instance.coins -= item.cost;
            UIManager.instance.coinsCount.text = GameController.instance.coins.ToString();
            item.OnBuy();
            //UIManager.instance.powerupIcons[id].SetActive(true);
        }
        else
        {
            Debug.Log("Pobre");
        }
    }
}
