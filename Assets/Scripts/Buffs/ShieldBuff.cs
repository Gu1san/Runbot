using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShield", menuName = "Buff/Shield")]
public class ShieldBuff : Item
{
    public int integrity;
    public override void OnBuy()
    {
        GameController.instance.shieldAvaliable = true;
    }
}
