using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UIManager : MonoBehaviour {

    // references
    [Header("References")]
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
    [Header("Right Panel")]
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
    [HideInInspector] public List<string> consoleArray;
    [HideInInspector] public string consoleLog;


    // start/end screens
    [Header("Start/End Screens")]
    [SerializeField] private GameObject howToPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endScreenPlayerHPValue;
    [SerializeField] private TextMeshProUGUI endScreenPlayerManaValue;
    [SerializeField] private TextMeshProUGUI endScreenEnemyHPValue;
    [SerializeField] private TextMeshProUGUI endScreenEnemyManaValue;
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject defeatText;


    //----------------------------------------------------------------------------------------------

    // right panel
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


    // start/end screens
    public void StartButton () {
        startPanel.SetActive(false);
        gameManager.SetTurnTo("PLAYER");
    }

    public void HowToButton() {
        howToPanel.SetActive(true);
    }

    public void ExitHowToButton() {
        howToPanel.SetActive(false);
    }

    public void ExitButton() {
        Application.Quit();
    }

    public void PlayAgainButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadStats() {
        endScreenPlayerHPValue.text = playerStats.GetHP().ToString();
        endScreenPlayerManaValue.text = playerStats.GetMana().ToString();
        endScreenEnemyHPValue.text = enemyStats.GetHP().ToString();
        endScreenEnemyManaValue.text = enemyStats.GetMana().ToString();
    }

    public GameObject GetEndPanel() {
        return endPanel;
    }

    public GameObject GetVictoryText() {
        return victoryText;
    }

    public GameObject GetDefeatText() {
        return defeatText;
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
