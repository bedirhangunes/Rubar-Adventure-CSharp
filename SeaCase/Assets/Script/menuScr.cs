using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScr : MonoBehaviour
{
  public void tartGame()
    {
        SceneManager.LoadScene("levelll");
    }
    public void xitGame()
    {
        Application.Quit();
    }
}
