using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    // references
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private EnemyAI enemyAI;


    // right panel
    [SerializeField] private TextMeshProUGUI turnValue;
    [SerializeField] private TextMeshProUGUI playerHPValue;
    [SerializeField] private Slider playerHPSlider;
    [SerializeField] private TextMeshProUGUI playerManaValue;
    [SerializeField] private Slider playerManaSlider;
    [SerializeField] private TextMeshProUGUI enemyHPValue;
    [SerializeField] private Slider enemyHPSlider;
    [SerializeField] private TextMeshProUGUI enemyManaValue;
    [SerializeField] private Slider enemyManaSlider;
    [SerializeField] private TextMeshProUGUI enemyStateValue;


    public void SetValueToSlider(int value, string agent) {

        switch(agent) {
            case "PLAYERHP": { playerHPSlider.value = value; break; }
            case "PLAYERMANA": { playerManaSlider.value = value; break; }
            case "ENEMYHP": { enemyHPSlider.value = value; break; }
            case "ENEMYMANA": { enemyManaSlider.value = value; break; }
        }
    }





    public void StartButton () {
        gameManager.SetTurnTo("PLAYER");
    }

    public void ChangeTurnButton() {
        if (gameManager.GetTurn() == GameManager.TURN.PLAYER) {
            gameManager.SetTurnTo("ENEMY");
        }

        else if (gameManager.GetTurn() == GameManager.TURN.ENEMY) {
            gameManager.SetTurnTo("PLAYER");
        }

    }

    public void EndButton() {
        gameManager.SetTurnTo("END");

    }


    // bottom panel



    // update
    void Update() {
        turnValue.text = gameManager.ConvertTurnToText(gameManager.GetTurn());
        playerHPValue.text = playerStats.GetHP().ToString();
        playerManaValue.text = playerStats.GetMana().ToString();
        enemyHPValue.text = enemyStats.GetHP().ToString();
        enemyManaValue.text = enemyStats.GetMana().ToString();
        enemyStateValue.text = enemyAI.ConvertStateToText(enemyAI.GetState());
    }


}
