using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castlespawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
     float gameSpeed;
    public List<string> waves= new List<string> { "1..1..1..111" };
    public point.direction facing;
    void Awake()
    {
        gameSpeed = gameManager.Instance.gamespeed;
        StartCoroutine(ReadEnemyWave());
    }

    IEnumerator ReadEnemyWave()
    {
        yield return new WaitForSecondsRealtime(10);
        for (int i = 0; i < 2; i++)
        {
            foreach (string wave in waves)
            {
                foreach (char action in wave)
                {
                    if (action == '.')
                    {
                        yield return new WaitForSecondsRealtime(gameSpeed);
                    }
                    else
                    {
                        instantiateEnemy(action);
                        yield return new WaitForSecondsRealtime(gameSpeed);

                    }
                }
                yield return new WaitForSecondsRealtime(5);
            }
            Debug.Log("end");
        }
        yield return new WaitForSecondsRealtime(7);
        gameManager.Instance.doneSpawn();

    }


    void instantiateEnemy(char enemy)
    {
        GameObject newEnemy=null;
        if (enemy == '1')
        {
           newEnemy = Instantiate(enemyOne);

        }
        else if (enemy == '2')
        {
            newEnemy = Instantiate(enemyTwo);
        }else if (enemy == '3')
        {
            newEnemy = Instantiate(enemyThree);
        }
        if (newEnemy != null)
        {
            newEnemy.GetComponent<enemyMover>().changeDirection(facing);
            newEnemy.transform.position = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
