using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool GameSarted;
    public int score;
    public Text scoretext;
    public Text highscoretext;
    private void Awake()
    {
        highscoretext.text = "HighScore: " + GetHighScore().ToString();
    }
    public void StartGame()
    {
        GameSarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public void IncreaseScore()
    {
        score++;
        scoretext.text = score.ToString();
        if(score> GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoretext.text = "HighScore: "+score.ToString();
        }
    }
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore") ;
        return i;

    }
}
