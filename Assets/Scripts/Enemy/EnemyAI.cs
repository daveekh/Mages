using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject player;
    private int randomDirection;
    private float timer;

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

    private void CheckStateConditions() {

        if (state == STATE.PATROL) {

            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 8 &&
                Mathf.Abs(transform.position.y - player.transform.position.y) <= 8) {

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

        if (timer > 3) {
            randomDirection = Random.Range(0, 4);

            switch(randomDirection) {
                case 0: { enemyMovement.MoveUp(); break; }
                case 1: { enemyMovement.MoveDown(); break; }
                case 2: { enemyMovement.MoveLeft(); break; }
                case 3: { enemyMovement.MoveRight(); break; }
            }

            gameManager.SetTurnTo("PLAYER");
            timer = 0;
        }
    }

    private void ActionState() {

        // action


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
