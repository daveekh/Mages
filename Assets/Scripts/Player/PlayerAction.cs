using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject enemy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerSpells playerSpells;
    [SerializeField] private PlayerStats playerStats;
    private int randomDmg;

    public void MovingUp() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerMovement.MoveUp();
            gameManager.AddLogToConsole("Gracz poruszył się do góry");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    public void MovingDown() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerMovement.MoveDown();
            gameManager.AddLogToConsole("Gracz poruszył się do dołu");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    public void MovingLeft() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerMovement.MoveLeft();
            gameManager.AddLogToConsole("Gracz poruszył się w lewo");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    public void MovingRight() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerMovement.MoveRight();
            gameManager.AddLogToConsole("Gracz poruszył się w prawo");
            gameManager.SetTurnTo("ENEMY");
        }
    }
 
    public void Fireball() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerSpells.Fireball();
            randomDmg = Random.Range(playerSpells.GetFireballDmgMin(), playerSpells.GetFireballDmgMax()+1);
            gameManager.DealDamageTo(randomDmg, "ENEMY");
            gameManager.SubtractMana(playerSpells.GetFireballManaCost(), "PLAYER");
            gameManager.AddLogToConsole("Gracz zaatakował kulą ognia zadając " + randomDmg + " obrażeń");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    public void Frostbolt() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerSpells.Frostbolt();
            randomDmg = Random.Range(playerSpells.GetFrostboltDmgMin(), playerSpells.GetFrostboltDmgMax()+1);
            gameManager.DealDamageTo(randomDmg, "ENEMY");
            gameManager.SubtractMana(playerSpells.GetFrostboltManaCost(), "PLAYER");
            gameManager.AddLogToConsole("Gracz zaatakował pociskiem lodu zadając " + randomDmg + " obrażeń");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    public void LightningBolt() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerSpells.LightningBolt();
            randomDmg = Random.Range(playerSpells.GetLightningBoltDmgMin(), playerSpells.GetLightningBoltDmgMax()+1);
            gameManager.DealDamageTo(randomDmg, "ENEMY");
            gameManager.SubtractMana(playerSpells.GetLightningBoltManaCost(), "PLAYER");
            gameManager.AddLogToConsole("Gracz zaatakował błyskawicą zadając " + randomDmg + " obrażeń");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    public void MagicStaffHit() {
        if(gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            playerSpells.MagicStaffHit();
            randomDmg = Random.Range(playerSpells.GetMagicStaffHitDmgMin(), playerSpells.GetMagicStaffHitDmgMax()+1);
            gameManager.DealDamageTo(randomDmg, "ENEMY");
            gameManager.SubtractMana(playerSpells.GetMagicStaffHitManaCost(), "PLAYER");
            gameManager.AddLogToConsole("Gracz zaatakował magicznym kijem zadając " + randomDmg + " obrażeń");
            gameManager.SetTurnTo("ENEMY");
        }
    }

    void Update() {

        if (gameManager.GetTurn() == GameManager.TURN.PLAYER) {

            // movement action - W S A D / Up Down Left Right
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                MovingUp();
            }

            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                MovingDown();
            }

            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                MovingLeft();
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                MovingRight();
            }



            // spell action - 1 2 3 4
            else if (Input.GetKeyDown(KeyCode.Alpha1)) {

                if(playerStats.GetMana() >= playerSpells.GetFireballManaCost()) {
                    if(
                        Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetFireballRange() &&
                        Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetFireballRange()
                    ) {
                        Fireball();
                    }
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2)) {

                if(playerStats.GetMana() >= playerSpells.GetFrostboltManaCost()) {
                    if(
                        Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetFrostboltRange() &&
                        Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetFrostboltRange()
                    ) {
                        Frostbolt();
                    } 
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3)) {

                if(playerStats.GetMana() >= playerSpells.GetLightningBoltManaCost()) {
                    if(
                        Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetLightningBoltRange() &&
                        Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetLightningBoltRange()
                    ) {
                        LightningBolt();
                    } 
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4)) {

                if(
                    Mathf.Abs(enemy.transform.position.x - transform.position.x) <= playerSpells.GetMagicStaffHitRange() &&
                    Mathf.Abs(enemy.transform.position.y - transform.position.y) <= playerSpells.GetMagicStaffHitRange()
                ) {
                    MagicStaffHit();
                }
            }
        }
    }
}
