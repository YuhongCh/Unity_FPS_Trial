using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public int damage;
    public GameObject Camera;
    public GameObject bulletPrefab;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            BulletBehavior bulletBehav = bullet.GetComponent<BulletBehavior>();
            bulletBehav.setDamage(damage);
            bullet.transform.position = Camera.transform.position + Camera.transform.forward;
            bullet.transform.forward = Camera.transform.forward;
        }
    }
}
