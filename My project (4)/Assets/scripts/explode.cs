using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        Destroy(gameObject,0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
