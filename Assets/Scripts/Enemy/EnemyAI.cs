using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyFuzzyLogic enemyFuzzyLogic;
    [SerializeField] private EnemySpells enemySpells;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject player;
    private int randomDirection;
    private float timer;
    private string spell;
    private float x, y;
    private int randomDmg;

    [HideInInspector]
    public enum STATE {
        PATROL, ACTION, RUN
    }

    private STATE state;

    public string ConvertStateToText(STATE state) {
        if (state == STATE.PATROL) return "Patrol";
        else if (state == STATE.ACTION) return "Action";
        else return "Run";
    }

    public void MoveTowardsPlayer() {

        x = Mathf.Abs(transform.position.x - player.transform.position.x);
        y = Mathf.Abs(transform.position.y - player.transform.position.y);

        if (transform.position.x < player.transform.position.x && transform.position.y > player.transform.position.y) {
            // przeciwnik jest w ćwiartka lewy górny

            if (x > y) {
                enemyMovement.MoveRight();
                gameManager.AddLogToConsole("Przeciwnik poruszył się w prawo");
            }
            else if (y > x) {
                enemyMovement.MoveDown();
                gameManager.AddLogToConsole("Przeciwnik poruszył się do dołu");
            }
            else {
                randomDirection = Random.Range(0, 2);

                switch(randomDirection) {
                    case 0: {
                        enemyMovement.MoveRight(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się w prawo");
                        break;
                    }
                    case 1: {
                        enemyMovement.MoveDown(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się do dołu");
                        break;
                    }
                }
            }
        } else if(transform.position.x > player.transform.position.x && transform.position.y > player.transform.position.y) {
            // przeciwnik jest w ćwiartka prawy górny

            if (x > y) {
                enemyMovement.MoveLeft();
                gameManager.AddLogToConsole("Przeciwnik poruszył się w lewo");
            }
            else if (y > x) {
                enemyMovement.MoveDown();
                gameManager.AddLogToConsole("Przeciwnik poruszył się do dołu");
            }
            else {
                randomDirection = Random.Range(0, 2);

                switch(randomDirection) {
                    case 0: {
                        enemyMovement.MoveLeft(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się w lewo");
                        break;
                    }
                    case 1: {
                        enemyMovement.MoveDown(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się do dołu");
                        break;
                    }
                }
            }
        } else if(transform.position.x > player.transform.position.x && transform.position.y < player.transform.position.y) {
            // przeciwnik jest w ćwiartka prawy dolny

            if (x > y) enemyMovement.MoveLeft();
            else if (y > x) enemyMovement.MoveUp();
            else {
                randomDirection = Random.Range(0, 2);

                switch(randomDirection) {
                    case 0: {
                        enemyMovement.MoveLeft(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się w lewo");
                        break;
                    }
                    case 1: {
                        enemyMovement.MoveUp(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się do góry");
                        break;
                    }
                }
            }
        } else {
            // przeciwnik jest w ćwiartka lewy dolny

            if (x > y) enemyMovement.MoveRight();
            else if (y > x) enemyMovement.MoveUp();
            else {
                randomDirection = Random.Range(0, 2);

                switch(randomDirection) {
                    case 0: {
                        enemyMovement.MoveRight(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się w prawo");
                        break;
                    }
                    case 1: {
                        enemyMovement.MoveUp(); 
                        gameManager.AddLogToConsole("Przeciwnik poruszył się do góry");
                        break;
                    }
                }
            }
        }
    } 

    private void CheckStateConditions() {

        if (state == STATE.PATROL) {

            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 6 &&
                Mathf.Abs(transform.position.y - player.transform.position.y) <= 6) {

                    state = STATE.ACTION;

            }

        }

        else if (state == STATE.ACTION) {


        }

        else {

        }
    }

    private void PatrollingState() {

        timer += Time.deltaTime;

        if (timer > 2) {
            randomDirection = Random.Range(0, 4);

            switch(randomDirection) {
                case 0: { 
                    enemyMovement.MoveUp(); 
                    gameManager.AddLogToConsole("Przeciwnik poruszył się do góry");
                    break; 
                }
                case 1: { 
                    enemyMovement.MoveDown(); 
                    gameManager.AddLogToConsole("Przeciwnik poruszył się do dołu");
                    break; 
                }
                case 2: { 
                    enemyMovement.MoveLeft(); 
                    gameManager.AddLogToConsole("Przeciwnik poruszył się w lewo");
                    break; 
                }
                case 3: { 
                    enemyMovement.MoveRight(); 
                    gameManager.AddLogToConsole("Przeciwnik poruszył się w prawo");
                    break; 
                }
            }

            gameManager.SetTurnTo("PLAYER");
            timer = 0;
        }
    }

    private void ActionState() {

        timer += Time.deltaTime;

        if (timer > 2)  {

            spell = enemyFuzzyLogic.EvaluateSpell(enemyStats.GetMana(), playerStats.GetHP());

            switch(spell) {
                case "LIGHTNING": { 
                    
                    if(
                        Mathf.Abs(transform.position.x - player.transform.position.x) <= enemySpells.GetLightningBoltRange() &&
                        Mathf.Abs(transform.position.y - player.transform.position.y) <= enemySpells.GetLightningBoltRange() &&
                        enemyStats.GetMana() >= enemySpells.GetLightningBoltManaCost()
                    ) {
                        enemySpells.LightningBolt();
                        //wait 2s
                        randomDmg = Random.Range(enemySpells.GetLightningBoltDmgMin(), enemySpells.GetLightningBoltDmgMax()+1);
                        gameManager.DealDamageTo(randomDmg, "PLAYER");
                        gameManager.SubtractMana(enemySpells.GetLightningBoltManaCost(), "ENEMY");
                        gameManager.AddLogToConsole("Przeciwnik zaatakował błyskawicą zadając " + randomDmg + " obrażeń");
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy Lightning Bolt! Dmg: " + randomDmg);
                        timer = 0;
                    
                    } else {
                        MoveTowardsPlayer();
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy moved towards player");
                        timer = 0;
                    }

                    break;
                }
                case "FIRE": {

                    if(
                        Mathf.Abs(transform.position.x - player.transform.position.x) <= enemySpells.GetFireballRange() &&
                        Mathf.Abs(transform.position.y - player.transform.position.y) <= enemySpells.GetFireballRange() &&
                        enemyStats.GetMana() >= enemySpells.GetFireballManaCost()
                    ) {
                        enemySpells.Fireball();
                        //wait 2s
                        randomDmg = Random.Range(enemySpells.GetFireballDmgMin(), enemySpells.GetFireballDmgMax()+1);
                        gameManager.DealDamageTo(randomDmg, "PLAYER");
                        gameManager.SubtractMana(enemySpells.GetFireballManaCost(), "ENEMY");
                        gameManager.AddLogToConsole("Przeciwnik zaatakował kulą ognia zadając " + randomDmg + " obrażeń");
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy Fireball! Dmg: " + randomDmg);
                        timer = 0;
                    
                    } else {
                        MoveTowardsPlayer();
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy moved towards player");
                        timer = 0;
                    }

                    break;
                }
                case "FROST": {

                    if(
                        Mathf.Abs(transform.position.x - player.transform.position.x) <= enemySpells.GetFrostboltRange() &&
                        Mathf.Abs(transform.position.y - player.transform.position.y) <= enemySpells.GetFrostboltRange() &&
                        enemyStats.GetMana() >= enemySpells.GetFrostboltManaCost()
                    ) {
                        enemySpells.Frostbolt();
                        //wait 2s
                        randomDmg = Random.Range(enemySpells.GetFrostboltDmgMin(), enemySpells.GetFrostboltDmgMax()+1);
                        gameManager.DealDamageTo(randomDmg, "PLAYER");
                        gameManager.SubtractMana(enemySpells.GetFrostboltManaCost(), "ENEMY");
                        gameManager.AddLogToConsole("Przeciwnik zaatakował pociskiem mrozu zadając " + randomDmg + " obrażeń");
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy Frostbolt! Dmg: " + randomDmg);
                        timer = 0;
                    
                    } else {
                        MoveTowardsPlayer();
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy moved towards player");
                        timer = 0;
                    }

                    break;
                }
                case "MAGICSTAFF": {
                    
                    if(
                        Mathf.Abs(transform.position.x - player.transform.position.x) <= enemySpells.GetMagicStaffHitRange() &&
                        Mathf.Abs(transform.position.y - player.transform.position.y) <= enemySpells.GetMagicStaffHitRange()
                    ) {
                        enemySpells.MagicStaffHit();
                        //wait 2s
                        randomDmg = Random.Range(enemySpells.GetMagicStaffHitDmgMin(), enemySpells.GetMagicStaffHitDmgMax()+1);
                        gameManager.DealDamageTo(randomDmg, "PLAYER");
                        gameManager.SubtractMana(enemySpells.GetMagicStaffHitManaCost(), "ENEMY");
                        gameManager.AddLogToConsole("Przeciwnik zaatakował magicznym kijem zadając " + randomDmg + " obrażeń");
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy Magic Staff Hit! Dmg: " + randomDmg);
                        timer = 0;
                    
                    } else {
                        MoveTowardsPlayer();
                        gameManager.SetTurnTo("PLAYER");
                        //Debug.Log("Enemy moved towards player");
                        timer = 0;
                    }

                    break;
                }
            }
        }
    }

    private void RunningState() {

        // running
    }

    void Start() {
        state = STATE.PATROL;
        timer = 0f;
    }

    void Update() {

        if (gameManager.GetTurn() == GameManager.TURN.ENEMY) {

            CheckStateConditions();

            if (state == STATE.PATROL) {
                PatrollingState();
            }

            else if (state == STATE.ACTION) {
                ActionState();
            }

            else  {
                RunningState();
            }
        }
    }

    public STATE GetState() { return state; }

}
