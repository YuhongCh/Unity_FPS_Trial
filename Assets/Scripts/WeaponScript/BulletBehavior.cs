using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    private float lifeDuration;
    private int damage;

    void Start()
    {
        lifeDuration = lifeTime;
    }

    void OnCollisionEnter(Collision col)
    {
        // this can be delete later as base class
        if (col.gameObject.tag == "Enemy") Destroy(gameObject);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeDuration -= Time.deltaTime;
        if (lifeDuration < 0f)
        {
            Destroy(gameObject);
        }
    }

    public void setDamage(int dmg)
    {
        damage = dmg;
    }

    public int getDamage()
    {
        return damage;
    }
}
