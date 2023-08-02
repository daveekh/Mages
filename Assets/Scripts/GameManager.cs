using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum TURN { 
        START, PLAYER, ENEMY, END
    }

    private TURN turn;

    public string ConvertTurnToText(TURN turn) {
        if (turn == TURN.START) return "Start";
        else if (turn == TURN.PLAYER) return "Player";
        else if (turn == TURN.ENEMY) return "Enemy";
        else return "End";
    }








    void Start() {
        turn = TURN.START;
    }

    void Update() {
        


    }

    public void setTurn(TURN turn) { this.turn = turn; }
    public TURN getTurn() { return turn; }

}
