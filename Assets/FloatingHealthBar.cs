using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    public float health = 1;
    public float maxHealth = 1;
    public bool isPlayer = false;
    public GameObject playerWithHealth = null;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(maxHealth);
        if(isPlayer && playerWithHealth!=null){
            playerWithHealth.transform.parent.GetComponent<Health>().health = health;
            playerWithHealth.transform.parent.GetComponent<Health>().maxHealth = maxHealth;
        }else{
            transform.parent.GetComponent<Health>().health = health;
            transform.parent.GetComponent<Health>().maxHealth = maxHealth;
        }

        if(!isPlayer)
            transform.rotation = Camera.main.transform.rotation;
        // transform.LookAt(Camera.main.transform);
        transform.Find("Slider").GetComponent<Slider>().value = health / maxHealth;
    }
}
