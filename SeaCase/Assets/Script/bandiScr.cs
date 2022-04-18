using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bandiScr : MonoBehaviour
{
    Animator anim;
    float horizontal, vertical;
    Vector3 vect;
    public Text scoreText;
    private bool jumpp;
    int score = 10;
    AudioSource audio;
    joybuttonn joybuton;
    Joystick joystick;
    void Start()
    {
        anim = GetComponent<Animator>();
        joybuton = FindObjectOfType<joybuttonn>();
        joystick = FindObjectOfType<Joystick>();
        scoreText.text = "LIFE: " + score;
        vect = new Vector3();
        audio = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        walked();
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 20f, rigidbody.velocity.y, joystick.Vertical * 20f);
        if (!jumpp&&joybuton.press)
        {
            GetComponent<Animator>().SetBool("run", true);
         
            jumpp = true;
        }
        else if(jumpp&&!joybuton.press)
        {
            GetComponent<Animator>().SetBool("run", false);
            jumpp = false;
        }
    }
   public void walked()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vect.Set(horizontal , 0, vertical);
        transform.Translate(vect * Time.deltaTime * 10f);
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "flag")
        {
            SceneManager.LoadScene("levelll");
        }
        if (col.tag == "Finish")
        {
            SceneManager.LoadScene("level1");
        }
        if(col.tag == "Respawn")
        {
            score--;
            scoreText.text = "LIFE: " + score;
            if (score == 0)
            {
                SceneManager.LoadScene("levelll");
            }
        }
    }
}
