using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerScript : MonoBehaviour
{
    public int shieldsHealth = 600;
    public int maxShieldsHealth = 600;

    public int coreHealth;
    public int maxCoreHealth;

    public GameObject[] shileds = new GameObject[3];
    public bool[] _shieldExists = new bool[3] {true,true,true};

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            if (shieldsHealth > 0)
            {
                shieldsHealth -= collision.gameObject.GetComponent<FireballSccript>().dmg;
                if (shieldsHealth <= 400 && _shieldExists[0])
                {
                    shileds[0].SetActive(false);
                    _shieldExists[0] = false;                
                }
                else if (shieldsHealth <= 200 && _shieldExists[1])
                {
                    shileds[1].SetActive(false);
                    _shieldExists[1] = false;
                }
                else if (shieldsHealth <= 0 && _shieldExists[2])
                {
                    shileds[2].SetActive(false);
                    _shieldExists[2] = false;
                }

            }
            else
            {
                maxCoreHealth -= collision.gameObject.GetComponent<FireballSccript>().dmg;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
