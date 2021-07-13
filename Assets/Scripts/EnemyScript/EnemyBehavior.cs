using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public float speed;

    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindWithTag ("Player").transform;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            BulletBehavior bullet = col.gameObject.GetComponent<BulletBehavior>();
            Health -= bullet.getDamage();
            Debug.Log("Enemy has HP " + Health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        if (Health <= 0) Destroy(gameObject);
    }

    public Transform getPlayerTransform()
    {
        return playerTransform;
    }

    public void receiveDamage(int damage)
    {
        Health -= damage;
    }
}
