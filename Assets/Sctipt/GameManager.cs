using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static GameManager Instance;
    

    public int score = 0;
    public float distance = 0;
    public TMP_Text scoreText;
    public TMP_Text highscore;
    public TMP_Text distanceText;


    private void Awake()
    {
        GameManager.Instance = this;
    }
    // Game start
    public void NewGame()
    {
        score = 0;
        Time.timeScale = 1f;
        LoadLevel();
    }
    
    void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    //CoinCollection
    public void Coincollected()
    {
        score++;
        scoreText.text = "Coins:" + score;
        highscore.text = "HighScore:" + score;
    }

    //DistanceCovered
    public void distancecovered()
    {
        distance += Time.deltaTime;
        distanceText.text = "Distance:" + (int)distance;
    }
}
