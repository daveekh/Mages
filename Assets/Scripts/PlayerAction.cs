using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [SerializeField] private GameManager gameManager;




    void ChangeTurnToEnemy() {
        gameManager.setTurn(GameManager.TURN.ENEMY);
    }

    void Start() {

    }

    void Update() {

        // check if enemy lives 

        if (gameManager.getTurn() == GameManager.TURN.PLAYER) {

            // movement action - W S A D / Up Down Left Right
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                ChangeTurnToEnemy();
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                ChangeTurnToEnemy();
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                ChangeTurnToEnemy();
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                ChangeTurnToEnemy();
            }

            // spell action - 1 2 3 4
            if (Input.GetKeyDown(KeyCode.Alpha1)) {



                ChangeTurnToEnemy();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {



                ChangeTurnToEnemy();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {



                ChangeTurnToEnemy();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4)) {



                ChangeTurnToEnemy();
            }
        }
    }
}
