using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5.0f;
    public bool player1 = true;

    void Start() {

    }

    void Update() {
        
        if (player1) {

            Player1Controls();

        } else {

            Player2Controls();

        }
    }

    void Player1Controls() {

        if (Input.GetKey(KeyCode.W)) {

            var mov = transform.position + Vector3.up * speed * Time.deltaTime;

            if (mov.y > 4.2f) {

                mov.y = 4.2f;
            }

            transform.position = mov;

        } else if (Input.GetKey(KeyCode.S)) {

            var mov = transform.position + Vector3.down * speed * Time.deltaTime;

            if (mov.y < -4.2f) {

                mov.y = -4.2f;
            }

            transform.position = mov;

        }
    }

    void Player2Controls() {

        if (Input.GetKey(KeyCode.UpArrow)) {

            var mov = transform.position + Vector3.up * speed * Time.deltaTime;

            if (mov.y > 4.2f) {

                mov.y = 4.2f;
            }

            transform.position = mov;

        } else if (Input.GetKey(KeyCode.DownArrow)) {

            var mov = transform.position + Vector3.down * speed * Time.deltaTime;

            if (mov.y < -4.2f) {

                mov.y = -4.2f;
            }

            transform.position = mov;

        }
    }

}