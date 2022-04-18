using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullScr : MonoBehaviour
{
   
    void Start()
    {
        BanditScr bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<BanditScr>();
        GetComponent<Rigidbody>().AddForce(bullet.bulleToPoint() * 3600);
        transform.rotation = Quaternion.LookRotation(bullet.bulleToPoint());
        Destroy(gameObject, 2);
    }

  
}
