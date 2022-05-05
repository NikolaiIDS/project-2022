using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    ThirdPersonScript Character;
    private Image Shield;
    public Text _shield;
    public float currShiled;
    private float maxShield;

    void Start()
    {
        Shield = GetComponent<Image>();
        Character = FindObjectOfType<ThirdPersonScript>();
        maxShield = Character.shieldMax;
    }

    // Update is called once per frame
    void Update()
    {
        _shield.text = $"{Mathf.Round(currShiled)} / {maxShield}";
        currShiled = Character.shieldDuration;
        Shield.fillAmount = currShiled / maxShield;
    }
}
