using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class charCapsul : MonoBehaviour
{
    public GameObject nisan, bullet;
    public Text  lifeText;
    private bool atesF;
    Vector3 vect;
    float horizontal, vertical,fire=0,fire2=0;
    int scor = 0,life=20;
    bool fired = false, fired2 = false;
    GameObject Ak47, charact;
    RaycastHit hit;
    Animator animator;
    AudioSource source;
    joybuttonn joyb;
    Joystick joyst;
    
    void Start()
    {
        vect = new Vector3();
        charact = GameObject.Find("CharCapsul").gameObject;
        Ak47 = charact.transform.GetChild(0).transform.GetChild(1).gameObject;
        //m48 = charact.transform.GetChild(0).transform.GetChild(2).gameObject;
        //m107 = charact.transform.GetChild(0).transform.GetChild(3).gameObject;
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        lifeText.text = "LIFE: " + life;
        joyb = FindObjectOfType<joybuttonn>();
        joyst = FindObjectOfType<Joystick>();

    }

   
    void Update()
    {
        //  hareket();
        var rigid = GetComponent<Rigidbody>();
        rigid.velocity = new Vector3(joyst.Horizontal * 30f, rigid.velocity.y, joyst.Vertical * 30f);
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, 100))
        //{
        //    transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        //}

        if (!atesF&&joyb.press)
            {
                fire += Time.deltaTime;
                if (fire > 0.5f)
                {

                    Instantiate(bullet, nisan.transform.position, Quaternion.identity);
                    fire = 0;
                source.Play();
                }

                fired = true;
            }
        else if(atesF&&!joyb.press)
        {
            fired = false;
            fire = 1;
        }
        rayCizdir();
    }
    void hareket()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vect.Set(horizontal, 0, vertical);
        transform.Translate(vect * Time.deltaTime * 20);
    }
    void rayCizdir()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log("Okey");
        }
        else
        {
            Debug.Log("Not");
        }
        Debug.DrawRay(ray.origin, ray.GetPoint(1000));
        Debug.DrawLine(nisan.transform.position,hit.point);

    }
    public Vector3 goToPoint()
    {
        return (hit.point - nisan.transform.position).normalized;
    }
     void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Enemyd")
        {
            life--;
            lifeText.text = "LIFE: " + life;
            if (life == 0)
            {
                SceneManager.LoadScene("level1");
            }
        }
        if (col.tag == "flag")
        {
            SceneManager.LoadScene("level3");
        }
        if (col.tag == "boom")
        {
            SceneManager.LoadScene("level2");
        }
    }
}
