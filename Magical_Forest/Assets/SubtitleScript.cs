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
    public NPCScript npc;
    public bool a = false;
    // Start is called before the first frame update
    void Update()
    {
        if (npc.subs && !a)
        {
            a = true;
            StartCoroutine(FiveSeconds());
        }

    }
    // Update is called once per frame
    IEnumerator FiveSeconds()
    {
        subtitles[current].SetActive(true);
        yield return new WaitForSeconds(5);
        subtitles[current].SetActive(false);
        current++;
        subtitles[current].SetActive(true);
        yield return new WaitForSeconds(10);
        subtitles[current].SetActive(false);
        current++;
        subtitles[current].SetActive(true);
        yield return new WaitForSeconds(12);
        subtitles[current].SetActive(false);
        current++;
        subtitles[current].SetActive(true);
        yield return new WaitForSeconds(10);
        subtitles[current].SetActive(false);
        current++;
        subtitles[current].SetActive(true);
        yield return new WaitForSeconds(10);
        subtitles[current].SetActive(false);
    }
}
