using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject weaponMenu;
    public GameObject _sub;
    public GameObject[] subtitles = new GameObject[3];
    public int current = 0;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && current < subtitles.Length - 2)
        {
            subtitles[current].SetActive(false);
            current++;
            subtitles[current].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.O) && current != 0 && current != subtitles.Length - 1)
        {
            subtitles[current].SetActive(false);
            current--;
            subtitles[current].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.X) && current == subtitles.Length - 2)
        {
            subtitles[current].SetActive(false);
            current++;
            subtitles[current].SetActive(true);
        }
        if (pauseMenu.activeSelf || weaponMenu.activeSelf) _sub.SetActive(false);
        else if (!pauseMenu.activeSelf || !weaponMenu.activeSelf) _sub.SetActive(true);

    }
}
