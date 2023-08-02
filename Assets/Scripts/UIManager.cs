using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI turnText;

    public void StartButton () {

        gameManager.setTurn(GameManager.TURN.PLAYER);

    }

    public void ChangeTurnButton() {

        if (gameManager.getTurn() == GameManager.TURN.PLAYER) {
            gameManager.setTurn(GameManager.TURN.ENEMY);
        }

        else if (gameManager.getTurn() == GameManager.TURN.ENEMY) {
            gameManager.setTurn(GameManager.TURN.PLAYER);
        }

    }

    public void EndButton() {

        gameManager.setTurn(GameManager.TURN.END);

    }

    void Update() {
        
        turnText.text = gameManager.ConvertTurnToText(gameManager.getTurn());
    }


}
