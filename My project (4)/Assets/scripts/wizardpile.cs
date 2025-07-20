using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardpile : MonoBehaviour
{

    [SerializeField] private int mana = 5;
    public int wizards = 1;
    public int powerPerWiz = 10;
    [Range(0.0f,1000f)]
    public float shotDelay = 500f;
    int combatpower;
    float cooldown = 0f;
    List<Collider2D> enemyQ;
    public GameObject SpawnedEnitity;
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= wizards; i++) { 
        AddWizard(); 
        wizards--;
        }

        enemyQ = new List<Collider2D>();
        combatpower = wizards*powerPerWiz;
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown > 0f){
        cooldown -= 500.0f*Time.deltaTime;
        }

        if (enemyQ.Count > 0 && cooldown <= 0f) {
        ShootAt(enemyQ[0].gameObject);
        cooldown = shotDelay/wizards;
        }
    }
    
    void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.tag == "enemy") 
        {
        enemyQ.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D enemy) {
        if (enemy.tag == "enemy") 
        {
        enemyQ.Remove(enemy);
        }
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

    public int GetMana()
    {
        return this.mana;
    }
}
