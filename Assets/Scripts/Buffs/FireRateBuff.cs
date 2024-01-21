using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFireRateBuff", menuName = "Buff/FireRate")]
public class FireRateBuff : Item
{
    public float multiplier;

    public override void OnBuy()
    {
        GameController.instance.buffFireRate = true;
    }
}
