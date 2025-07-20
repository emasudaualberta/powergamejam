using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour
{

    public Image curtain;
    int currentscene = 0;

    public List<GameObject> scenes;
    // Start is called before the first frame update
    void Start()
    {
        curtain.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(nextScene());
        }
    }


    IEnumerator nextScene()
    {
        StartCoroutine(fadeCurtain());
        yield return new WaitForSeconds(1);
        scenes[currentscene].SetActive(false);
        currentscene++;
        if (currentscene >= scenes.Count) {
            SceneManager.LoadScene(1);
        }


    }

    IEnumerator fadeCurtain()
    {
        while (curtain.color.a < 100)
            curtain.color = new Color(0,0,0,curtain.color.a+1);
            yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);

        while (curtain.color.a > 0)
            curtain.color = new Color(0, 0, 0, curtain.color.a - 1);
            yield return new WaitForSeconds(1f);
    }
}
