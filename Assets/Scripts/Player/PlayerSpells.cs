using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private int testSpell1Dmg = 30;
    [SerializeField] private int testSpell1Range = 8;
    [SerializeField] private GameObject testSpell1Missile;
    private GameObject missile;
    private float x, y;
    private Quaternion rotation;

    public void TestSpell1() {

        x = Mathf.Abs(enemy.transform.position.x - transform.position.x);
        y = Mathf.Abs(enemy.transform.position.y - transform.position.y);

        rotation = Quaternion.Euler(0, 0, Mathf.Atan2(x, y) * Mathf.Rad2Deg);

        StartCoroutine(Move(testSpell1Missile, rotation, enemy.transform.position));
    }




    private IEnumerator Move(GameObject spell, Quaternion rotation, Vector3 targetPos) {

        missile = Instantiate(spell, transform.position, rotation);

        float elapsedTime = 0;
        float timeToMove = 1f;
        Vector3 origPos = missile.transform.position;

        while(elapsedTime < timeToMove) {
            missile.transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        missile.transform.position = targetPos;
        Destroy(missile);
    }

    public int GetTestSpell1Dmg() { return testSpell1Dmg; }
    public int GetTestSpell1Range() { return testSpell1Range; }
}
