using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour {

    // references
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerAction playerAction;
    [SerializeField] private PlayerSpells playerSpells;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private Button fireballButton;
    [SerializeField] private Button frostboltButton;
    [SerializeField] private Button lightningBoltButton;
    [SerializeField] private Button magicStaffHitButton;


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
    [SerializeField] private TextMeshProUGUI consoleArrayValue;
    public List<string> consoleArray;
    public string consoleLog;


    public void SetValueToSlider(int value, string agent) {

        switch(agent) {
            case "PLAYERHP": { playerHPSlider.value = value; break; }
            case "PLAYERMANA": { playerManaSlider.value = value; break; }
            case "ENEMYHP": { enemyHPSlider.value = value; break; }
            case "ENEMYMANA": { enemyManaSlider.value = value; break; }
        }
    }

    public void AddLogToConsole(string log) {
        consoleArray.Add(log);
    
        consoleLog = "";

        foreach(string x in consoleArray) {
            consoleLog += x;
            consoleLog += "\n";
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
    public void SetActiveButtons() {

        //Fireball
        if(
            playerStats.GetMana() >= playerSpells.GetFireballManaCost() && 
            Mathf.Abs(enemy.transform.position.x - player.transform.position.x) <= playerSpells.GetFireballRange() &&
            Mathf.Abs(enemy.transform.position.y - player.transform.position.y) <= playerSpells.GetFireballRange()
            ) { 
                fireballButton.interactable = true;

            } else {
                fireballButton.interactable = false;
            }

        //Frostbolt
        if(
            playerStats.GetMana() >= playerSpells.GetFrostboltManaCost() && 
            Mathf.Abs(enemy.transform.position.x - player.transform.position.x) <= playerSpells.GetFrostboltRange() &&
            Mathf.Abs(enemy.transform.position.y - player.transform.position.y) <= playerSpells.GetFrostboltRange()
            ) { 
                frostboltButton.interactable = true;

            } else {
                frostboltButton.interactable = false;
            }

        //Lightning Bolt
        if(
            playerStats.GetMana() >= playerSpells.GetLightningBoltManaCost() && 
            Mathf.Abs(enemy.transform.position.x - player.transform.position.x) <= playerSpells.GetLightningBoltRange() &&
            Mathf.Abs(enemy.transform.position.y - player.transform.position.y) <= playerSpells.GetLightningBoltRange()
            ) { 
                lightningBoltButton.interactable = true;

            } else {
                lightningBoltButton.interactable = false;
            }

        //Magic Staff Hit
        if(
            playerStats.GetMana() >= playerSpells.GetMagicStaffHitManaCost() && 
            Mathf.Abs(enemy.transform.position.x - player.transform.position.x) <= playerSpells.GetMagicStaffHitRange() &&
            Mathf.Abs(enemy.transform.position.y - player.transform.position.y) <= playerSpells.GetMagicStaffHitRange()
            ) { 
                magicStaffHitButton.interactable = true;

            } else {
                magicStaffHitButton.interactable = false;
            }
    }



    // update
    void Update() {
        turnValue.text = gameManager.ConvertTurnToText(gameManager.GetTurn());
        playerHPValue.text = playerStats.GetHP().ToString();
        playerManaValue.text = playerStats.GetMana().ToString();
        enemyHPValue.text = enemyStats.GetHP().ToString();
        enemyManaValue.text = enemyStats.GetMana().ToString();
        enemyStateValue.text = enemyAI.ConvertStateToText(enemyAI.GetState());
        consoleArrayValue.text = consoleLog.ToString();
        SetActiveButtons();
    }


}
