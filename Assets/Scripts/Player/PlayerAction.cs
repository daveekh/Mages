using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject enemy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerSpells playerSpells;
    private int randomDmg;
 
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

                // Fireball
                if(
                    Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetFireballRange() &&
                    Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetFireballRange()
                ) {
                    playerSpells.Fireball();
                    // wait 2 seconds
                    randomDmg = Random.Range(playerSpells.GetFireballDmgMin(), playerSpells.GetFireballDmgMax()+1);
                    gameManager.DealDamageTo(randomDmg, "ENEMY");
                    gameManager.DeduceMana(playerSpells.GetFireballManaCost(), "PLAYER");
                    gameManager.SetTurnTo("ENEMY");
                    Debug.Log("Fireball! Dmg: " + randomDmg);
                } else {
                    Debug.Log("You're too far!");
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2)) {

                // Frostbolt
                if(
                    Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetFrostboltRange() &&
                    Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetFrostboltRange()
                ) {
                    playerSpells.Frostbolt();
                    // wait 2 seconds
                    randomDmg = Random.Range(playerSpells.GetFrostboltDmgMin(), playerSpells.GetFrostboltDmgMax()+1);
                    gameManager.DealDamageTo(randomDmg, "ENEMY");
                    gameManager.DeduceMana(playerSpells.GetFrostboltManaCost(), "PLAYER");
                    gameManager.SetTurnTo("ENEMY");
                    Debug.Log("Frostbolt! Dmg: " + randomDmg);
                } else {
                    Debug.Log("You're too far!");
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3)) {

                // Lighting Bolt
                if(
                    Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetLightningBoltRange() &&
                    Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetLightningBoltRange()
                ) {
                    playerSpells.LightningBolt();
                    // wait 2 seconds
                    randomDmg = Random.Range(playerSpells.GetLightningBoltDmgMin(), playerSpells.GetLightningBoltDmgMax()+1);
                    gameManager.DealDamageTo(randomDmg, "ENEMY");
                    gameManager.DeduceMana(playerSpells.GetLightningBoltManaCost(), "PLAYER");
                    gameManager.SetTurnTo("ENEMY");
                    Debug.Log("Lightning Bolt! Dmg: " + randomDmg);
                } else {
                    Debug.Log("You're too far!");
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4)) {

                // Magic Staff Hit
                if(
                    Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetMagicStaffHitRange() &&
                    Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetMagicStaffHitRange()
                ) {
                    playerSpells.MagicStaffHit();
                    // wait 2 seconds
                    randomDmg = Random.Range(playerSpells.GetMagicStaffHitDmgMin(), playerSpells.GetMagicStaffHitDmgMax()+1);
                    gameManager.DealDamageTo(randomDmg, "ENEMY");
                    gameManager.DeduceMana(playerSpells.GetMagicStaffHitManaCost(), "PLAYER");
                    gameManager.SetTurnTo("ENEMY");
                    Debug.Log("Magic Staff Hit! Dmg: " + randomDmg);
                } else {
                    Debug.Log("You're too far!");
                }
            }
        }
    }
}
