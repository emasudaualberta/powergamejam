
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public GameObject BombExplosion;
    public int damage = 70;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
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
            GameObject explode = Instantiate(BombExplosion, transform.position, Quaternion.identity);
            Destroy(explode, 0.3f);
        
        }
    }
}
