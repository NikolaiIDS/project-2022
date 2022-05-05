using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    ThirdPersonScript Character;
    private Image HealthBAr;
    public Text _health;
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
        _health.text = (int)currHealth + "/" + (int)maxHealth;
        currHealth = Character.health;
        HealthBAr.fillAmount = currHealth / maxHealth;
    }
}
