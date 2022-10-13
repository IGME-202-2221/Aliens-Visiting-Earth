using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// canvas system namespace
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // variables data (reference to whatever has the data for score and health)
    public float score;

    GameObject player;

    // reference to hub components
    [SerializeField]
    Text scoreLabel;

    [SerializeField]
    Slider healthSlider;

    private void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // update score
        scoreLabel.text = "SCORE: " + score;

        // update player health
        healthSlider.value = player.GetComponent<Player>().Health;
    }
}
