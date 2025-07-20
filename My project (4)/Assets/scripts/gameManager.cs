using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float gamespeed = 0.7f; //time taken to complete a spawn action
    public int hp = 100;
    void Start()
    {
        
    }

    private static gameManager _instance;

    public static gameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<gameManager>();
            }

            return _instance;
        }
    }


    public void takeDamage()
    {
        hp--;
        GameObject.FindGameObjectWithTag("hp").gameObject.GetComponent<TextMeshPro>().text = $"HP:{hp}";
        if (hp <= 0) { }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
