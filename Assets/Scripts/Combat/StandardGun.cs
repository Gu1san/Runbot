using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGun : Gun
{
    public override void Shoot()
    {
        if (Input.GetMouseButton(0) && (Time.time > timerShoot))
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
            Invoke("SecondShot", fireRate / 2);
        }
    }

    void SecondShot()
    {
        GameObject bullet = PoolAPI.instance.Pool.Get();
        if (bullet != null)
        {
            bullet.transform.position = barrel[1].transform.position;
            bullet.transform.rotation = bullet.transform.rotation * transform.rotation;
            bullet.SetActive(true);
        }
        particle[1].Play();
        shotSound.Play();
    }
}
