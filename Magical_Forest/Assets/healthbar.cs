using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Image HealthBAr;
    public float currHealth;
    private float maxHealth = 200f;
    ThirdPersonScript Character;
    void Start()
    {
        HealthBAr = GetComponent<Image>();
        Character = FindObjectOfType<ThirdPersonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Character.health;
        HealthBAr.fillAmount = currHealth / maxHealth;
    }
}
