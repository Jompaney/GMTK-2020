﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject OptionsMenu;
    void Start()
    {
        OptionsMenu = GameObject.Find("OptionsMenu");
        OptionsMenu.SetActive(false);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsButton()
    {
        OptionsMenu.SetActive(true);
    }

    public void OptionsExitButton()
    {
        OptionsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        Debug.Log("Exiting");
        Application.Quit();
        
    }
}
