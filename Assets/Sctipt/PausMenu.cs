using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausMenu : MonoBehaviour
{
    public GameObject PausPanel;
    public Button _continue, _restart, _menu;

    private void Awake()
    {
        _continue.onClick.AddListener(Continue);
        _restart.onClick.AddListener(Restart);
        _menu.onClick.AddListener(Menu);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        
    }
    public void Continue()
    {
        PausPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        PausPanel.SetActive(!PausPanel.activeSelf);
        {
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        GameManager.Instance.RestartLevel();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
