using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.0f,1000f)]
    public int damage;
    [Range(0.0f,20f)]
    public float range;
    void Start()
    {
        //Debug.Log(transform.position);
        if (damage != 0 && range != 0f) {
            CircleCollider2D cc = gameObject.AddComponent<CircleCollider2D>();
            cc.isTrigger = true;
            cc.radius = range;  
        }

        Destroy(gameObject,0.8f);
    }

    void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.tag == "enemy") {
            GameObject tHit = enemy.gameObject;
            tHit.GetComponent<enemyMover>().TakeDamage(damage);
        } 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
