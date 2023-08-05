using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject enemy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerSpells playerSpells;
 
    void Update() {

        if (gameManager.GetTurn() == GameManager.TURN.PLAYER) {

            // movement action - W S A D / Up Down Left Right
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                playerMovement.MoveUp();
                gameManager.SetTurnTo("ENEMY");
            }

            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                playerMovement.MoveDown();
                gameManager.SetTurnTo("ENEMY");
            }

            else  if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                playerMovement.MoveLeft();
                gameManager.SetTurnTo("ENEMY");
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                playerMovement.MoveRight();
                gameManager.SetTurnTo("ENEMY");
            }



            // spell action - 1 2 3 4
            else if (Input.GetKeyDown(KeyCode.Alpha1)) {

                if(
                    Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetTestSpell1Range() &&
                    Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetTestSpell1Range()
                ) {
                    
                    
                    playerSpells.TestSpell1();
                    gameManager.DealDamageTo(playerSpells.GetTestSpell1Dmg(), "ENEMY");
                    gameManager.SetTurnTo("ENEMY");

                } else {
                    Debug.Log("You're too far!");
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2)) {



                gameManager.SetTurnTo("ENEMY");
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3)) {



                gameManager.SetTurnTo("ENEMY");
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4)) {



                gameManager.SetTurnTo("ENEMY");
            }
        }
    }
}
