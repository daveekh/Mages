using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    [SerializeField] private UIManager uiManager;
    [SerializeField] private int hp = 100;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int mana = 200;
    [SerializeField] private int maxMana = 200;
    [SerializeField] private int regenHp = 5;
    [SerializeField] private int regenMana = 15;

    public void SetHP(int hp) { this.hp = hp; }
    public void SetMana(int mana) { this.mana = mana; }
    public int GetHP() { return hp; }
    public int GetMana() { return mana; }
    public void RegenStats() {
        hp += regenHp;
        mana += regenMana;

        if(hp > maxHp) hp = maxHp;
        if(mana > maxMana) mana = maxMana;

        uiManager.SetValueToSlider(hp, "ENEMYHP");
        uiManager.SetValueToSlider(mana, "ENEMYMANA");
    }

}
