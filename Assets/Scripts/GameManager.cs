using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private UIManager uiManager;

    [HideInInspector]
    public enum TURN { 
        START, PLAYER, ENEMY, END
    }

    private TURN turn;

    public string ConvertTurnToText(TURN turn) {
        if (turn == TURN.START) return "Start";
        else if (turn == TURN.PLAYER) return "Gracz";
        else if (turn == TURN.ENEMY) return "Przeciwnik";
        else return "Koniec";
    }

    public void AddLogToConsole(string log) {
        uiManager.AddLogToConsole(log);
    }

    public void SetTurnTo(string turn) {

        switch(turn) {
            case "START": { this.turn = TURN.START; break; }

            case "PLAYER": { 

                if(playerStats.GetHP() <= 0) {
                    playerStats.SetHP(0);
                    this.turn = TURN.END;
                    StartCoroutine(PlayerDefeat());
                }
                else {
                    this.turn = TURN.PLAYER; 
                    playerStats.RegenStats();
                }
                break;
            }

            case "ENEMY": { 

                if(enemyStats.GetHP() <= 0) {
                    enemyStats.SetHP(0);
                    this.turn = TURN.END;
                    StartCoroutine(EnemyDefeat());
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
            uiManager.SetValueToSlider(playerStats.GetHP(), "PLAYERHP");
        }
        else if(name == "ENEMY") {
            enemyStats.SetHP(enemyStats.GetHP() - value);  
            uiManager.SetValueToSlider(enemyStats.GetHP(), "ENEMYHP");
        }
    }

    public void SubtractMana(int value, string name) {
        if(name == "PLAYER") {
            playerStats.SetMana(playerStats.GetMana() - value);
            uiManager.SetValueToSlider(playerStats.GetMana(), "PLAYERMANA");

            if(playerStats.GetMana() < 0) playerStats.SetMana(0);

        }
        else if(name == "ENEMY") {
            enemyStats.SetMana(enemyStats.GetMana() - value);   
            uiManager.SetValueToSlider(enemyStats.GetMana(), "ENEMYMANA");

            if(enemyStats.GetMana() < 0) enemyStats.SetMana(0);
        }
    }

    public IEnumerator PlayerDefeat() {
        yield return new WaitForSeconds(1.1f);

        // player death anim

        // yield return new WaitForSeconds(3);

        uiManager.LoadStats();
        uiManager.GetEndPanel().SetActive(true);
        uiManager.GetDefeatText().SetActive(true);
    }

    public IEnumerator EnemyDefeat() {
        yield return new WaitForSeconds(1.1f);

        // enemy death anim

        // yield return new WaitForSeconds(3);

        uiManager.LoadStats();
        uiManager.GetEndPanel().SetActive(true);
        uiManager.GetVictoryText().SetActive(true);
    }



    void Start() {
        turn = TURN.START;
    }

    public TURN GetTurn() { return turn; }

}
