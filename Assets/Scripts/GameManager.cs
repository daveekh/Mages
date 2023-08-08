using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private EnemyStats enemyStats;

    [HideInInspector]
    public enum TURN { 
        START, PLAYER, ENEMY, END, VICTORY, DEFEAT
    }

    private TURN turn;

    public string ConvertTurnToText(TURN turn) {
        if (turn == TURN.START) return "Start";
        else if (turn == TURN.PLAYER) return "Player";
        else if (turn == TURN.ENEMY) return "Enemy";
        else return "End";
    }

    public void SetTurnTo(string turn) {

        switch(turn) {
            case "START": { this.turn = TURN.START; break; }

            case "PLAYER": { 

                if(playerStats.GetHP() <= 0) {
                    this.turn = TURN.END; 
                }
                else {
                    this.turn = TURN.PLAYER; 
                    playerStats.RegenStats();
                }
                break;
            }

            case "ENEMY": { 

                if(enemyStats.GetHP() <= 0) {
                    this.turn = TURN.END;
                }
                else {
                    this.turn = TURN.ENEMY; 
                    enemyStats.RegenStats();
                }
                break;
            }

            case "END": { this.turn = TURN.END; break; }
        }

    }

    public void DealDamageTo(int value, string name) {
        if(name == "PLAYER") {
            playerStats.SetHP(playerStats.GetHP() - value);
        }
        else if(name == "ENEMY") {
            enemyStats.SetHP(enemyStats.GetHP() - value);   
        }
    }

    public void SubtractMana(int value, string name) {
        if(name == "PLAYER") {
            playerStats.SetMana(playerStats.GetHP() - value);
        }
        else if(name == "ENEMY") {
            enemyStats.SetMana(enemyStats.GetHP() - value);   
        }
    }

    void Start() {
        turn = TURN.START;
    }

    //public void SetTurn(TURN turn) { this.turn = turn; }
    public TURN GetTurn() { return turn; }

}
