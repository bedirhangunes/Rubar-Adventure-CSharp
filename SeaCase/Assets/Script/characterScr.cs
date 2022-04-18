using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterScr : MonoBehaviour
{
    AudioSource audiosource;
    bool fire = false;
    public Text lifeT;
    public GameObject bullet, target;
    protected bool agirrr;
    Vector3 vector;
    float horizontal, vertical, fired = 0;
    int score, lifee = 15;
    GameObject ak47,charc;
    RaycastHit hit;
    Animator animator;
    joybuttonn joybutton;
    Joystick joystick;

    void Start()
    {
        vector = new Vector3();
        animator=GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        charc = GameObject.Find("Character").gameObject;
        ak47 = charc.transform.GetChild(0).transform.GetChild(1).gameObject;
        joybutton = FindObjectOfType<joybuttonn>();
        joystick = FindObjectOfType<Joystick>();

    }

   
    void Update()
    {
        charWalk();
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 30f, rigidbody.velocity.y, joystick.Vertical * 30f);
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if(Physics.Raycast(ray,out hit, 5))
        //{
        //    transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        //}
        if (!agirrr&&joybutton.press)
        {
            fired += Time.deltaTime;
            if (fired > 0.5f)
            {
                Instantiate(bullet, target.transform.position, Quaternion.identity);
                audiosource.Play();
                fired = 0;
            }
            fire = true;
        }
        else if(agirrr&&!joybutton.press)
        {
            fired = 1;
            fire = false;
        }
        rayDrawed();
    }
    void charWalk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vector.Set(horizontal, 0, vertical);
        transform.Translate(vector * Time.deltaTime * 20);
    }
    void rayDrawed()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log("Yes");
        }
        else
        {
            Debug.Log("not okey");
        }
        Debug.DrawRay(ray.origin, ray.GetPoint(1000));
        Debug.DrawLine(target.transform.position, hit.point);
    }
    public Vector3 bullToPoint()
    {
        return (hit.point - target.transform.position).normalized;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "sword")
        {
            SceneManager.LoadScene("level3");
        }
        if (col.tag == "fence")
        {
            SceneManager.LoadScene("level3");
        }
        if (col.tag == "flage")
        {
            SceneManager.LoadScene("finish");
        }
      
    }
}
