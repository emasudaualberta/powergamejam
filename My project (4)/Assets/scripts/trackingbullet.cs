using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingbullet : MonoBehaviour
{

    public GameObject trackingObject;
    public int damage = 50;
    Vector3 lastpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setTarget(GameObject target)
    {
        trackingObject = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingObject != null)
        {
            lastpos = trackingObject.transform.position;

        }
        else
        {
            Destroy(gameObject);
        }
       
        transform.position = Vector3.MoveTowards(transform.position, lastpos, 6 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject tHit = collision.gameObject;
        if (collision.tag == "enemy") {
            tHit.GetComponent<enemyMover>().TakeDamage(damage);
            Destroy(gameObject);
        } 
    }
}
