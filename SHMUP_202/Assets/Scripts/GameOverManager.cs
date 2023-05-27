using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    GameObject gameOverPanel;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // get a reference to the game over panel UI
        gameOverPanel = GameObject.Find("Game Over Menu");
        player = GameObject.Find("player");

        // disable this menu on start
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player health reaches 0, show game over screen
        if (player.GetComponent<Player>().Health <= 0)
        {
            gameOverPanel.SetActive(true);
            SaveHighscore(player.GetComponent<Player>().Score);
        }
    }

    public void StartGame()
    {
        // loads the main playable level in the queue
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        PlayerPrefs.Save();

        // loads the main menu
        SceneManager.LoadScene(0);
    }

    // save score data
    public void SaveHighscore(int score)
    {
        // if player's score is greater than highschore,
        // save current score as new highscore
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
