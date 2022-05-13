using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AnimationStateController animStateController;


    public static bool Paused = false;
    public GameObject menuUI;
    public GameObject settings;
    public GameObject menu;
    bool sett = false;
    public GameObject swordsMenu;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject sword3;
    public GameObject sword4;
    public GameObject staff;
    public GameObject swordpng1;
    public GameObject swordpng2;
    public GameObject swordpng3;
    public GameObject swordpng4;
    bool holdings;
    bool holding1;
    bool holding2;
    bool holding3;
    bool holding4;
    public GameObject puzzleUI;

    public ThirdPersonScript tps;
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
        if (Paused == false && Input.GetKeyDown(KeyCode.Tab))
        {
            SwordMenu();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            SwordMenunt();
        }

    }
    public void Resume()
    {
        if (puzzleUI.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        
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
    public void SwordMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        swordsMenu.SetActive(true);
    }
    public void Item1()
    {
        if (holding2 || holding3 || holding4)
        {

            sword2.SetActive(false);
            sword3.SetActive(false);
            sword4.SetActive(false);
            swordpng2.SetActive(false);
            swordpng3.SetActive(false);
            swordpng4.SetActive(false);
            animStateController.WandController();
        }
        sword1.SetActive(true);
        swordpng1.SetActive(true);
        staff.SetActive(false);
        holding1 = true;
        animStateController.SwordController();

    }
    public void Item2()
    {
        if (holding1 || holding3 || holding4)
        {
            sword1.SetActive(false);
            sword3.SetActive(false);
            sword4.SetActive(false);
            swordpng1.SetActive(false);
            swordpng3.SetActive(false);
            swordpng4.SetActive(false);
            animStateController.WandController();
        }
        sword2.SetActive(true);
        swordpng2.SetActive(true);
        staff.SetActive(false);
        holding2 = true;
        animStateController.SwordController();

    }
    public void Item3()
    {
        if (holding1 || holding2 || holding4)
        {
            sword1.SetActive(false);
            sword2.SetActive(false);
            sword4.SetActive(false);
            swordpng1.SetActive(false);
            swordpng2.SetActive(false);
            swordpng4.SetActive(false);
        }
        sword3.SetActive(true);
        swordpng3.SetActive(true);
        staff.SetActive(false);
        holding3 = true;
        animStateController.SwordController();

    }
    public void Item4()
    {
        if (holding1 || holding2 || holding3)
        {
            sword1.SetActive(false);
            sword2.SetActive(false);
            sword3.SetActive(false);
            swordpng1.SetActive(false);
            swordpng2.SetActive(false);
            swordpng3.SetActive(false);

        }
        sword4.SetActive(true);
        swordpng4.SetActive(true);

        staff.SetActive(false);
        holding4 = true;
        animStateController.SwordController();
    }
    public void Staff()
    {
        if (holding1 || holding2 || holding3 || holding4)
        {
            sword1.SetActive(false);
            sword2.SetActive(false);
            sword3.SetActive(false);
            sword4.SetActive(false);
            swordpng1.SetActive(false);
            swordpng2.SetActive(false);
            swordpng3.SetActive(false);
            swordpng4.SetActive(false);
        }
        staff.SetActive(true);
        holding1 = false;
        holding2 = false;
        holding3 = false;
        holding4 = false;
        animStateController.WandController();
    }

    public void SwordMenunt()
    {
        swordsMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
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
        animStateController = GameObject.Find("Character").GetComponent<AnimationStateController>();
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

        SaveSystem.SavePlayer(tps);
        SceneManager.LoadScene("SimpleNaturePack_Demo");
    }

}
