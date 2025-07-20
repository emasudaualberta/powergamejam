using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingbullet : MonoBehaviour
{

    public GameObject trackingObject;
    [Range(0.0f, 1.0f)] public float speed = 0.5f;
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

        Vector3 delta = lastpos-transform.position;
        transform.position = transform.position + delta.normalized*speed*Time.deltaTime*50f;
        transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.up,delta)*Mathf.Sign(-delta.x), Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject tHit = collision.gameObject;
        if (collision.tag == "enemy") {
            tHit.GetComponent<enemyMover>().TakeDamage(damage);
            Destroy(gameObject);
        } 
    }
}
