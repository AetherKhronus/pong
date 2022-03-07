using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public Text scoreLeftText;
    public Text scoreRightText;
    public int maxScore = 10;

    private static int scoreLeft;
    private static int scoreRight;
    private GameObject ball;

    void Start() {
        
        ball = GameObject.FindGameObjectWithTag("Ball");
        scoreRightText.text = "00";
        scoreLeftText.text = "00";
        scoreLeft = 0;
        scoreRight = 0;
    }

    void Update() {
        
        if (scoreLeft == maxScore || scoreRight == maxScore) {

            EndGame();

        }
    }

    void EndGame() {

        PlayerPrefs.SetInt("scoreRight" , scoreRight);
        PlayerPrefs.SetInt("scoreLeft" , scoreLeft);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void AddScore(int player) {

        if (player != 1) {

            scoreLeft++;

            if (scoreLeft < 10) {

                scoreLeftText.text = "0" + scoreLeft.ToString();

            } else {

                scoreLeftText.text = scoreLeft.ToString();

            }

        } else {

            scoreRight++;

            if (scoreRight < 10) {

                scoreRightText.text = "0" + scoreRight.ToString();

            } else {

                scoreRightText.text = scoreRight.ToString();

            }

        }

    }

}
