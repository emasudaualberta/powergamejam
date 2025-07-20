using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingbullet : MonoBehaviour
{

    GameObject trackingObject;
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
        if (trackingObject != null) {

        }
        Debug.Log("asdfa");
        transform.position += Vector3.forward * Time.deltaTime;
    }
}
