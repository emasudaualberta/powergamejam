using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyscript : MonoBehaviour
{
    //public Tilemap _tileset;
    //public Vector3 _tilepos;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Trigger!");
        Debug.Log(target.name);
        Debug.Log(target.transform.position);
    }

    void OnColliderEnter2D(Collider2D target)
    {
        Debug.Log("Collider!");
        Debug.Log(target.name);
        Debug.Log(target.transform.position);
    }

    void OnCollisionStay2d(Collider2D target)
    {
        Debug.Log("ColliderStay!");
        Debug.Log(target.name);
        Debug.Log(target.transform.position);
    }
}
