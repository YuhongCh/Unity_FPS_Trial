using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is from Unity official, understand it later
public class LaserGunBehave : MonoBehaviour {

    public int damage = 1; 
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public Transform gunEnd;

    public Camera fpsCam;

    private LineRenderer laserLine;
    private float nextFire;


    void Start () 
    {
        laserLine = GetComponent<LineRenderer>();
    }


    void Update () 
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
        
            StartCoroutine (ShotEffect());
            
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition (0, gunEnd.position);

            if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    EnemyBehavior enemy = hit.collider.GetComponent<EnemyBehavior>();
                    enemy.receiveDamage(damage);
                }
            }
            laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
        }
    }


    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(0.07f);
        laserLine.enabled = false;
    }
}