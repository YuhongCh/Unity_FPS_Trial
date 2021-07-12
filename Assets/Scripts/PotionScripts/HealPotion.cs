using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : PotionBehavior
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            HealthBarBehavior HealthBar = col.gameObject.GetComponent<HealthBarBehavior>();
            HealthBar.setHealth(HealthBar.getHealth() - 2);
            gameObject.SetActive(false);
        }
    }
}
