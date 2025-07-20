using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardpile : MonoBehaviour
{


    public int wizards = 1;
    public int powerPerWiz = 10;
    int combatpower;
    float cooldown = 0f;
    List<Collider2D> enemyQ;
    public GameObject SpawnedEnitity;
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        enemyQ = new List<Collider2D>();
        combatpower = wizards*powerPerWiz;
    }

    // Update is called once per frame
    void Update()
    {
        AddWizard();

        if (cooldown > 0f){
        cooldown -= 1.0f;
        }

        if (enemyQ.Count > 0 && cooldown <= 0f) {
        ShootAt(enemyQ[0].gameObject);
        cooldown = 100f;
        }
    }
    
    void OnTriggerEnter2D(Collider2D enemy) {
        enemyQ.Add(enemy);
    }

    void OnTriggerExit2D(Collider2D enemy) {
        enemyQ.Remove(enemy);
    }

    void AddWizard() {
        wizards += 1;
        GameObject newwiz = Instantiate(SpawnedEnitity, this.transform);
        Vector2 newpos = Random.insideUnitCircle*0.6f;
        newwiz.transform.localPosition = new Vector3(newpos.x,newpos.y*0.8f,0);
        combatpower = wizards*powerPerWiz;
    }

    void ShootAt(GameObject target) {
        //Bullet proj = Instantiate(Projectile, this.transform);
        //proj.target = target;
        GameObject proj = Instantiate(Projectile,transform);
        if (proj.GetComponent<trackingbullet>() != null) {
            proj.GetComponent<trackingbullet>().setTarget(target);


        }
    }



}
