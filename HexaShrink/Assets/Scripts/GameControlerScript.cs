using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlerScript : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas GameUI;
    public Canvas PauseMenu;
    public Canvas HowToPlayMenu;
    public Button pauseButton;
    public Canvas GameOverUI;
    public Text GameOverScore;

    public GameObject hexagon;
    public GameObject player;

    public GameObject center;

    public bool isPlaying = false;
    public float spawnRate = 1.0f;

    float nextTimeToSpawn = 0.0f;
    int score = 0;

    public void play()
    {
        MainMenu.gameObject.SetActive(false);
        updateScore(0);
        GameUI.gameObject.SetActive(true);
        Instantiate(player, new Vector3(0.0f, 0.6f, 0.0f), Quaternion.identity);
        center.SetActive(true);
        isPlaying = true;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void pause()
    {
        pauseButton.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void resume()
    {
       pauseButton.gameObject.SetActive(true);
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void backToMenu()
    {
        pauseButton.gameObject.SetActive(true);
        GameUI.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
        HowToPlayMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        isPlaying = false;
        center.SetActive(false);
        score = 0;
        Time.timeScale = 1.0f;
    }

    public void gameOver()
    {
        pauseButton.gameObject.SetActive(true);
        GameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(true);
        center.SetActive(false);
        isPlaying = false;
        GameOverScore.text = "Score : " + score;
    }

    public void howToPlay()
    {
        MainMenu.gameObject.SetActive(false);
        HowToPlayMenu.gameObject.SetActive(true);
    }

    public void updateScore(int point = 1)
    {
        score += point;
        GameUI.GetComponentInChildren<Text>().text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (Time.time > nextTimeToSpawn)
            {
                Instantiate(hexagon, Vector3.zero, Quaternion.identity);
                nextTimeToSpawn = Time.time + 1 / spawnRate;
            }
        }
    }
}
