using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiautomaticGun : Gun
{
    public override void Shoot()
    {
        if (Input.GetMouseButtonDown(GameController.instance.doubleGun ? 1 : 0) && (Time.time > timerShoot))
        {
            if (!GameController.instance.buffFireRate)
            {
                timerShoot = Time.time + fireRate;
            }
            else
            {
                timerShoot = Time.time + (fireRate * 0.8f);
            }
            GameObject bullet = PoolAPI.instance.Pool.Get();
            if (bullet != null)
            {
                bullet.transform.position = barrel[0].transform.position;
                bullet.transform.rotation = bullet.transform.rotation * transform.rotation;
                bullet.SetActive(true);
            }
            particle[0].Play();
            shotSound.Play();
        }
    }
}
