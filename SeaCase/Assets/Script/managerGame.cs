using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class managerGame : MonoBehaviour
{
    public GameObject targetss;
    public Vector3 randomm;
    public Text textOfScr;
    int score = 0;

    void Start()
    {
        StartCoroutine(create());
        textOfScr.text = "SCORE: " + score;
    }

   
   IEnumerator create()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            for(int e = 0; e < 3; e++)
            {
                Vector3 cred = new Vector3(Random.Range(-randomm.x, randomm.x), randomm.y,-randomm.z);
                Instantiate(targetss, cred, Quaternion.identity);
                yield return new WaitForSeconds(6);
            }
            yield return new WaitForSeconds(6);
        }
    }
    public void scoreWrite(int skorr)
    {
        score += skorr;
        textOfScr.text = "SCORE: " + score;
        if (score == 12)
        {
            SceneManager.LoadScene("level2");
        }
    }
}
