using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject menuPanel;

    private bool menuActive;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive == false)
            {
                MenuPausa();
            }
            else
            {
                Resume();
            }
        }
    }

    public void MenuPausa()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
        menuActive = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        menuActive = false;
    }
}
