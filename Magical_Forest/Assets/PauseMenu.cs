using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject menuUI;
    public GameObject settings;
    public GameObject menu;
    bool sett = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused && sett == false)
            {

                Resume();
            }
            else 
            {
                Pause();

            }
        }
        if (sett == true && Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(false); menu.SetActive(true); sett = false;
        }
       


    }
    public void Resume()
    {
        Cursor.visible = false;
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Pause()
    {
        Cursor.visible = true;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            menuUI.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Settings()
    {
        settings.SetActive(true); menu.SetActive(false);
        sett = true;
    }
    public void Back()
    {
        settings.SetActive(false); menu.SetActive(true);
        sett = false;
    }
    public Texture2D cursorArrow;

    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SimpleNaturePack_Demo");
    }

}
