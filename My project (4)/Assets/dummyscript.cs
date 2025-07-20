using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyscript : MonoBehaviour
{
    //public Tilemap _tileset;
    //public Vector3 _tilepos;
    // Update is called once per frame
    // im going to kill myself
    void OnTriggerEnter2D(Collider2D target)
    {
        if(Input.GetKey(KeyCode.F))
        {
            Debug.Log("loll");
        }
    }
    /*
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Debug.Log("loll");
        }
    }
    */
}
