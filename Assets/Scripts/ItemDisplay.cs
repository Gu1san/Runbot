using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Item item;

    public Text nameText;
    public Text description;
    public Text cost;

    public Image icon;

    void Start()
    {
        nameText.text = item.name;
        description.text = item.description;
        if(cost != null)
        {
            cost.text = item.cost.ToString();
        }
        icon.sprite = item.icon;
    }
}
