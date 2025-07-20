using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject tHit = collision.gameObject;
        if (collision.tag == "enemy")
        {
            tHit.GetComponent<enemyMover>().TakeDamage(damage);
            Destroy(gameObject);

        }
    }
}
