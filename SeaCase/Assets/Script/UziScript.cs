using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziScript : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform target;
    public float impulse = 2050.0f;
    float fire = 0;
    bool firecontroled = false;
    RaycastHit hit;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fire += Time.deltaTime;
            if (fire > 0.3f)
            {
                Rigidbody bull = (Rigidbody)Instantiate(bullet, target.position + target.forward, target.rotation);
                bullet.AddForce(target.forward * impulse, ForceMode.Impulse);
                fire = 0;
            }
            firecontroled = true;
        }
        else
        {
            firecontroled = false;
        }
    }
  
}
