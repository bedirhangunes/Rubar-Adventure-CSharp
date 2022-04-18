using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BanditScr : MonoBehaviour
{
    Animator animatorr;
    AudioSource audio;
    bool firee = false;
    float horizontal, vertical, fired = 0;
    GameObject pistol;
    int score;
    protected bool agir;
    public GameObject bullet, nisan;
    RaycastHit hit;
    Vector2 vector;
    joybuttonn joybutt;
    Joystick joystick;
    void Start()
    {
        animatorr = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        joybutt = FindObjectOfType<joybuttonn>();
        joystick = FindObjectOfType<Joystick>();
        vector = new Vector2();

    }

   
    void Update()
    {
        // hareket();
        var rigbod = GetComponent<Rigidbody>();
        rigbod.velocity = new Vector2(joystick.Horizontal * 10f, 0);
        if (joystick.Horizontal == 1)
        {
            GetComponent<Animator>().SetBool("fire", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("fire", false);
        }
        if (!agir&&joybutt.press)
        {
            fired += Time.deltaTime;
            GetComponent<Animator>().SetBool("fire", true);
            if (fired > 0.7f)
            {
                Instantiate(bullet, nisan.transform.position, Quaternion.identity);
                audio.Play();
                fired = 0;

            }
        }
        else if(agir&&!joybutt.press)
        {
            GetComponent<Animator>().SetBool("fire", false);
        }
        rayDrawing();
    }
    //void hareket()
    //{
    //    horizontal = Input.GetAxis("Horizontal");
    //    vertical = Input.GetAxis("Vertical");
    //    vector.Set(horizontal,0);
    //    transform.Translate(vector * Time.deltaTime * 30);
    //}
   void rayDrawing()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log("Saw");
        }
        else
        {
            Debug.Log("not saw");
        }
        Debug.DrawRay(ray.origin, ray.GetPoint(1000));
        Debug.DrawLine(nisan.transform.position, hit.point);
    }
    public Vector3 bulleToPoint()
    {
        return (hit.point - nisan.transform.position).normalized;
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "boom")
        {
            SceneManager.LoadScene("level1");
        }
    }
}
