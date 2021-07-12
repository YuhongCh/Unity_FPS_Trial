using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehavior : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, rotateSpeed * Time.deltaTime);
    }
}
