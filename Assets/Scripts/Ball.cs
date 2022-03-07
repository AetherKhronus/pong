using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 3.0f;
    public float maxSpeed = 7.0f;
    public float addSpeed = 1.1f;
    public float currentSpeed = 0.0f;

    private Vector3 direction;
    private Vector3 movement;
    private bool isMoving;
    private GameObject gameManager;

    void Start() {
        
        gameManager = GameObject.Find("/Managers/Game Manager");

        Invoke("RandomizeStart" , 2);

    }

    void Update() {

        if (isMoving) {

            transform.position = transform.position + movement * Time.deltaTime;

            if (movement.x < 0) {

                currentSpeed = movement.x * -1;

            } else {

                currentSpeed = movement.x;
            }
            

        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Border") {

            GetComponent<AudioSource>().Play();
            HitBorder();

        } 
        
        if (other.tag == "Player") {

            GetComponent<AudioSource>().Play();
            HitPlayer(other);

        } 

        if (other.tag == "Goal") {

            HitGoal(other);

        } 

    }

    private void ResetBall() {

        transform.position = new Vector3(0 , 0 , 0);
        isMoving = false;
        movement = new Vector3(0 , 0 , 0);
        currentSpeed = 0.0f;

    }

    public void RandomizeStart() {

        isMoving = true;

        direction = new Vector2(Random.Range(-1 , 2) , Random.Range(-1 , 2));

        while (direction.x == 0) {

           direction.x = Random.Range(-1 , 2);
        }

        movement.x = direction.x * speed;
        movement.y = direction.y * Random.Range(0.1f , speed + 1);

    }

    private void HitPlayer(Collider2D player) {

        movement.x = movement.x * -1;

        if (currentSpeed * addSpeed < maxSpeed) {

            movement.x = movement.x * addSpeed;

        }

        if (player.transform.position.x > 0) { //Right

            if (Input.GetKey(KeyCode.UpArrow)) {

                UpMovement();

            } else if (Input.GetKey(KeyCode.DownArrow)) {

                DownMovement();

            }

        } else { //Left

            if (Input.GetKey(KeyCode.W)) {

                UpMovement();

            } else if (Input.GetKey(KeyCode.S)) {

                DownMovement();

            }

        }

    }

    private void UpMovement() {

        if (movement.y == 0) {

            movement.y = movement.y + 0.4f * Random.Range(1.0f , 1.6f);

        } else if (movement.y < 0) {

            movement.y = movement.y + 0.2f * Random.Range(1.0f , 1.6f);

        } else {

            movement.y = movement.y + 0.6f * Random.Range(1.0f , 1.6f);
        }
    }

    private void DownMovement() {

        if (movement.y == 0) {

            movement.y = movement.y - 0.4f * Random.Range(1.0f , 1.6f);

        } else if (movement.y < 0) {

            movement.y = movement.y - 0.6f * Random.Range(1.0f , 1.6f);

        } else {

            movement.y = movement.y - 0.2f * Random.Range(1.0f , 1.6f);
        }

    }

    private void HitBorder() {

        movement.y = movement.y * -1 * Random.Range(0.8f , 1.2f);

    }

    private void HitGoal(Collider2D other) {

        if (other.transform.position.x > 0) {   //Right

            gameManager.SendMessage("AddScore", 2 , SendMessageOptions.RequireReceiver);

        } else {    //Left

            gameManager.SendMessage("AddScore", 1 , SendMessageOptions.RequireReceiver);
        }

        ResetBall();
        Invoke("RandomizeStart" , 4);
        
    }
}
