using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpells : MonoBehaviour {

    [SerializeField] private GameObject player;
    [Header("Fireball")]
    [SerializeField] private int fireballDmgMin = 20;
    [SerializeField] private int fireballDmgMax = 30;
    [SerializeField] private int fireballRange = 5;
    [SerializeField] private int fireballManaCost = 60;
    [SerializeField] private GameObject fireballMissile;
    //animacja fireballa
    [Header("Frostbolt")]
    [SerializeField] private int frostboltDmgMin = 15;
    [SerializeField] private int frostboltDmgMax = 20;
    [SerializeField] private int frostboltRange = 3;
    [SerializeField] private int frostboltManaCost = 40;
    [SerializeField] private GameObject frostboltMissile;
    // animacja frostbolta
    [Header("Lightning Bolt")]
    [SerializeField] private int lightningBoltDmgMin = 10;
    [SerializeField] private int lightningBoltDmgMax = 35;
    [SerializeField] private int lightningBoltRange = 6;
    [SerializeField] private int lightningBoltManaCost = 50;
    // animacja lightning bolta
    [Header("Magic Staff Hit")]
    [SerializeField] private int magicStaffHitDmgMin = 5;
    [SerializeField] private int magicStaffHitDmgMax = 10;
    [SerializeField] private int magicStaffHitRange = 1;
    [SerializeField] private int magicStaffHitManaCost = 0;
    // animacja magic staffa

    private GameObject missile;
    private float x, y;
    private Quaternion rotation;


    public void Fireball() {

        x = Mathf.Abs(transform.position.x - player.transform.position.x);
        y = Mathf.Abs(transform.position.y - player.transform.position.y);

        if( (transform.position.x > player.transform.position.x && transform.position.y < player.transform.position.y) ||
            (transform.position.x < player.transform.position.x && transform.position.y > player.transform.position.y) ) {
            
            rotation = Quaternion.Euler(0, 0, Mathf.Atan2(x, y) * Mathf.Rad2Deg);
        } else {
            rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(x, y) * Mathf.Rad2Deg);
        }

        StartCoroutine(Move(fireballMissile, rotation, player.transform.position));
        // animacja wybuchu
    }

    public void Frostbolt() {

        x = Mathf.Abs(transform.position.x - player.transform.position.x);
        y = Mathf.Abs(transform.position.y - player.transform.position.y);

        if( (transform.position.x > player.transform.position.x && transform.position.y < player.transform.position.y) ||
            (transform.position.x < player.transform.position.x && transform.position.y > player.transform.position.y) ) {
            
            rotation = Quaternion.Euler(0, 0, Mathf.Atan2(x, y) * Mathf.Rad2Deg);
        } else {
            rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(x, y) * Mathf.Rad2Deg);
        }

        StartCoroutine(Move(frostboltMissile, rotation, player.transform.position));
        // animacja wybuchu
    }

    public void LightningBolt() {
        // animacja wybuchu
    }

    public void MagicStaffHit() {
        // animacja uderzenia
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

    public int GetFireballDmgMin() { return fireballDmgMin; }
    public int GetFireballDmgMax() { return fireballDmgMax; }
    public int GetFireballRange() { return fireballRange; }
    public int GetFireballManaCost() { return fireballManaCost; }

    public int GetFrostboltDmgMin() { return frostboltDmgMin; }
    public int GetFrostboltDmgMax() { return frostboltDmgMax; }
    public int GetFrostboltRange() { return frostboltRange; }
    public int GetFrostboltManaCost() { return frostboltManaCost; }

    public int GetLightningBoltDmgMin() { return lightningBoltDmgMin; }
    public int GetLightningBoltDmgMax() { return lightningBoltDmgMax; }
    public int GetLightningBoltRange() { return lightningBoltRange; }
    public int GetLightningBoltManaCost() { return lightningBoltManaCost; }

    public int GetMagicStaffHitDmgMin() { return magicStaffHitDmgMin; }
    public int GetMagicStaffHitDmgMax() { return magicStaffHitDmgMax; }
    public int GetMagicStaffHitRange() { return magicStaffHitRange; }
    public int GetMagicStaffHitManaCost() { return magicStaffHitManaCost; }




}
