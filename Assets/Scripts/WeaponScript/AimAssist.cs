using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssist : MonoBehaviour
{
    public float magnitude;
    private Vector3 enlarge;

    void Start()
    {
        enlarge = new Vector3(magnitude, magnitude, magnitude);
    }

    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(shootBullet());
        }
    }

    IEnumerator shootBullet()
    {
        transform.localScale += enlarge;
        yield return new WaitForSeconds(0.1f);
        transform.localScale -= enlarge; 
    }
}
