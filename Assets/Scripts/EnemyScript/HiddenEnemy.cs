using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemy : EnemyBehavior
{
    public Material activeMaterial;
    public float activeDistance;
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, getPlayerTransform().position);
        if (distance <= activeDistance)
        {
            gameObject.GetComponent<MeshRenderer> ().material = activeMaterial;
            transform.position = Vector3.MoveTowards(transform.position, getPlayerTransform().position, speed * Time.deltaTime);
        }
    }

    
}
