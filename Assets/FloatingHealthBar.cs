using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    public float health = 1;
    public float maxHealth = 1;
    public bool isPlayer = false;
    public Health healthComponent;
    public Slider healthSlider;

    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(maxHealth);
        if(isPlayer && healthComponent != null){
            health = healthComponent.health;
            maxHealth = healthComponent.maxHealth;
        }else{
            health = healthComponent.health;
            maxHealth = healthComponent.maxHealth;
        }

        if(!isPlayer)
            transform.rotation = Camera.main.transform.rotation;
        // transform.LookAt(Camera.main.transform);
        healthSlider.value = health / maxHealth;
    }
}
