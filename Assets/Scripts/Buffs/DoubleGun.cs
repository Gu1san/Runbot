using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDoubleGun", menuName = "Buff/DoubleGun")]
public class DoubleGun : Item
{
    public Gun secondaryGun;
    public override void OnBuy()
    {
        GameController.instance.doubleGun = true;
    }
}
