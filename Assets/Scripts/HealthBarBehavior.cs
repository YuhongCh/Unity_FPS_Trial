using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int HealthPoint;

    void Start()
    {
        fill.color = gradient.Evaluate(1f);
        slider.value = HealthPoint;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            HealthPoint -= 1;
            slider.value = HealthPoint;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            Debug.Log("Player has Health" + HealthPoint);
        }
    }
    void Update()
    {
        if (HealthPoint <= 0) Destroy(gameObject);
    }

    public void setHealth(int HP)
    {
        HealthPoint = HP;
        slider.value = HealthPoint;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.Log("Player has Health" + HealthPoint);
    }

    public int getHealth()
    {
        return HealthPoint;
    }
    
}
