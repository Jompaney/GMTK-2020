﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerMain : MonoBehaviour
{
    private GameObject OptionsMenu;
    private GameObject Menu;
    void Start()
    {
        OptionsMenu = GameObject.Find("OptionsMenu");
        OptionsMenu.SetActive(false);

        Menu = GameObject.Find("Menu");
        Menu.SetActive(false);
    }

    public void MenuButton()
    {
        Menu.SetActive(true);
    }

    public void ExitMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OptionsExit()
    {
        OptionsMenu.SetActive(false);
    }

    public void ExitToGame()
    {
        Menu.SetActive(false);
    }

    public void OptionsButton()
    {
        OptionsMenu.SetActive(true);
    }

    public void ExitDesktopButton()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
