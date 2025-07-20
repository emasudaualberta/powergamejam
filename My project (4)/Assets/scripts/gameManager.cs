using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float gamespeed = 0.7f; //time taken to complete a spawn action
    public int hp = 26;
    public int spawnersDone = 0;
    void Start()
    {
        takeDamage();
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

    public void doneSpawn()
    {
        spawnersDone++;
        if (spawnersDone > 3)
        {
            SceneManager.LoadScene(3);
        }
    }


    public void takeDamage()
    {
        hp--;
        GameObject.FindGameObjectWithTag("hp").GetComponent<TextMeshProUGUI>().text = $"HP:{hp}";
        if (hp <= 0) {
            SceneManager.LoadScene(2);
        }
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
