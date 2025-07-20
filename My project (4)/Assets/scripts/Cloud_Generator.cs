using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public float cooldown = 500f;
    public GameObject cloud;
    [Range(0.0f, 1.0f)]
    public float phase;
    float currentcool;

    void Start()
    {
        currentcool = (1f - phase)*cooldown ;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentcool <= 0) {
            Instantiate(cloud,this.transform);
            currentcool = cooldown;
        } else {
        currentcool -= Time.deltaTime*100f;
        }
    }
}
