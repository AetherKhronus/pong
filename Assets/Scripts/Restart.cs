using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public Text winner;

    private int scoreLeft;
    private int scoreRight;

    private void Start() {

        scoreLeft = PlayerPrefs.GetInt("scoreLeft");
        scoreRight = PlayerPrefs.GetInt("scoreRight");

        if (scoreLeft > scoreRight) {

            winner.text = "Player 1 Wins!";

        } else {

            winner.text = "Player 2 Wins!";
        }

        PlayerPrefs.SetInt("scoreLeft" , 0);
        PlayerPrefs.SetInt("scoreRight" , 0);
        PlayerPrefs.Save();
    }

    public void Replay() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void Exit() {

        Application.Quit();

    }
}
