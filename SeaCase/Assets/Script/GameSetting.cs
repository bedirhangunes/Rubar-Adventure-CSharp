using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    public Vector3 random;
    public GameObject skeletion;
    public Text SkorText;
    int scored = 0;

    void Start()
    {
        random = new Vector3();
        StartCoroutine(creatEnemy());
        SkorText.text = "SCORE: " + scored;
    }

   
IEnumerator creatEnemy()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            for(int i = 0; i < 5; i++)
            {
                Vector3 enmy = new Vector3(Random.Range(-random.x, random.x), random.y,  random.z);
                Instantiate(skeletion, enmy, Quaternion.identity);
                yield return new WaitForSeconds(5);
            }
        }
    }
    public void scorePlus(int scor)
    {
        scored += scor;
        SkorText.text = "SCORE: " + scored;
    }
        
}
