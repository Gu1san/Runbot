using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Item item;

    public Text nameText;
    public Text description;
    public Text cost;
    [SerializeField] Button buyButton;

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

    public void Buy()
    {
        Shop.instance.Buy(item);
    }
}
