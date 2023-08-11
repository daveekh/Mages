using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFuzzyLogic : MonoBehaviour {

    [Header("Enemy's Mana")]
    [SerializeField] private AnimationCurve EMLightningBoltCurve;
    [SerializeField] private AnimationCurve EMFireballCurve;
    [SerializeField] private AnimationCurve EMFrostboltCurve;

    [Header("Player's HP")]
    [SerializeField] private AnimationCurve HPLightningBoltCurve;
    [SerializeField] private AnimationCurve HPFireballCurve;
    [SerializeField] private AnimationCurve HPFrostboltCurve;


    private float EMLightningBoltCurveValue;
    private float EMFireballCurveValue;
    private float EMFrostboltCurveValue;
    private float HPLightningBoltCurveValue;
    private float HPFireballCurveValue;
    private float HPFrostboltCurveValue;
    private float lightningBoltFinalValue;
    private float fireballFinalValue;
    private float frostboltFinalValue;
    private float setA;
    private float setB;
    private float setC;

    private float chosenSpell;
    private string spellString;

    public string EvaluateSpell(int enemyMana, int playerHP) {
        
        // if playerHP < 20 consider adding instakill from enemy

        if(enemyMana < 40) {
            spellString = "MAGICSTAFF";
        } else {
            EMLightningBoltCurveValue = EMLightningBoltCurve.Evaluate(enemyMana);
            EMFireballCurveValue = EMFireballCurve.Evaluate(enemyMana);
            EMFrostboltCurveValue = EMFrostboltCurve.Evaluate(enemyMana);
            HPLightningBoltCurveValue = HPLightningBoltCurve.Evaluate(playerHP);
            HPFireballCurveValue = HPFireballCurve.Evaluate(playerHP);
            HPFrostboltCurveValue = HPFrostboltCurve.Evaluate(playerHP);

            lightningBoltFinalValue = EMLightningBoltCurveValue + HPLightningBoltCurveValue;
            fireballFinalValue = EMFireballCurveValue + HPFireballCurveValue;
            frostboltFinalValue = EMFrostboltCurveValue + HPFrostboltCurveValue;

            setA = lightningBoltFinalValue;
            setB = lightningBoltFinalValue + fireballFinalValue;
            setC = lightningBoltFinalValue + fireballFinalValue + frostboltFinalValue;

            chosenSpell = Random.Range(0, setC);

            if(chosenSpell >= 0 && chosenSpell < setA) {
                spellString = "LIGHTNING";
            } else if(chosenSpell >= setA && chosenSpell < setB) {
                spellString = "FIRE";
            } else {
                spellString = "FROST";
            }
        }

        return spellString;
    }


}
