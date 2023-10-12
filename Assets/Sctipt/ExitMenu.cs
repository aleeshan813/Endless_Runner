using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitMenu : MonoBehaviour
{
    public GameObject ExitPanel;
    public AudioSource ExitSource;

    public Button _restart, _menu;

    private void Awake()
    {
        _restart.onClick.AddListener(GameOver);
        _menu.onClick.AddListener(Menu);
    }
   
    public void Pause()
    {
        ExitPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
