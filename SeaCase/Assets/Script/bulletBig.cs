using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBig : MonoBehaviour
{
   
    void Start()
    {
        characterScr scr = GameObject.FindGameObjectWithTag("Player").GetComponent<characterScr>();
        GetComponent<Rigidbody>().AddForce(scr.bullToPoint() * 3750);
        transform.rotation = Quaternion.LookRotation(scr.bullToPoint());
        Destroy(gameObject, 5);
    }

   
}
