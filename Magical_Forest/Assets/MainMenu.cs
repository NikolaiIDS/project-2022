using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public void PlayGame()
    {
        SceneManager.LoadScene("Demo");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Back()
    {
        settings.SetActive(false); menu.SetActive(true);
    }
    public void Settings()
    {
        settings.SetActive(true); menu.SetActive(false);
    }

}