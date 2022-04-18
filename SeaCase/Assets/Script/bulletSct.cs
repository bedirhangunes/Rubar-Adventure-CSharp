using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSct : MonoBehaviour
{
   
    void Start()
    {
        charCapsul bul = GameObject.FindGameObjectWithTag("Player").GetComponent<charCapsul>();
        GetComponent<Rigidbody>().AddForce(bul.goToPoint() * 3500);
        transform.rotation = Quaternion.LookRotation(bul.goToPoint());
        Destroy(gameObject, 3);
    }

   
   
}
