using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    GameObject highscoreText;

    private void Start()
    {
        // load and display current hischore
        highscoreText.GetComponent<TextMesh>().text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    public void StartGame()
    {
        // loads the main playable level in the queue
        SceneManager.LoadScene(1);
    }
}
