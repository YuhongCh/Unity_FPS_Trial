using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMachineGunBehave : GunBehavior
{

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(shootBullet());
        }
    }

    IEnumerator shootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        BulletBehavior bulletBehav = bullet.GetComponent<BulletBehavior>();
        bulletBehav.setDamage(damage);
        bullet.transform.position = Camera.transform.position + Camera.transform.forward;
        bullet.transform.forward = Camera.transform.forward;
        yield return new WaitForSeconds(0.1f);
    }
}
