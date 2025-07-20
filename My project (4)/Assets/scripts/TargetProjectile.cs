
using UnityEngine;

public class TargetProjectile : MonoBehaviour
{
    private Vector3 mousePos;
    private float mousey = 0f;
    public GameObject plane;
    public int damage = 50;
    private GameObject planeobj;
    public GameObject BombExplosion;
    public bool exist = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TargetProjectile started");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousey = mousePos.y;
        Invoke("spawnplane", 2);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void spawnplane()
    {
        Vector3 planelocation = new Vector3(mousePos.x, -20, 0);
        planeobj = Instantiate(plane, planelocation, Quaternion.identity);
        Rigidbody2D rb = planeobj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * 20;
        }
        Invoke("spawnbomb", 2);
        Destroy(planeobj, 10);

    }
    void spawnbomb()
    {
        GameObject explode = Instantiate(BombExplosion, transform.position, Quaternion.identity);
        Destroy(explode, 0.3f);
    }
    void Update()
    {
 

    }

}
