using UnityEngine.UI;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    private ThirdPersonScript tps;
    public Text coins;
    // Start is called before the first frame update
    void Start()
    {
        tps = GameObject.Find("Character").GetComponent<ThirdPersonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = tps.coins.ToString();
    }
}
