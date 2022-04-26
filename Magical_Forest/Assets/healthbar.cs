using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    ThirdPersonScript Character;
    private Image HealthBAr;
    public float currHealth;
    private float maxHealth;
    
    void Start()
    {
        
        HealthBAr = GetComponent<Image>();
        Character = FindObjectOfType<ThirdPersonScript>();
        maxHealth = Character.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Character.health;
        HealthBAr.fillAmount = currHealth / maxHealth;
    }
}
