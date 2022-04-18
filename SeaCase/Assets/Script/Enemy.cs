using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animat;
    public GameObject target, explosion;
    float menzil = 12f, mesafe;//hedefle dusman arasý mesafe
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animat = GetComponent<Animator>();
    }

   
    void Update()
    {
        mesafe = Vector3.Distance(target.transform.position, transform.position);
        if (mesafe <= menzil)
        {
            agent.SetDestination(target.transform.position);
            animat.SetBool("runn", true);
        }
        else
        {
            animat.SetBool("runn", false);
        }
    }
    private void OnDrawGizmosSelected()//Enemy see target,follow 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, menzil);
    }
     void OnTriggerEnter(Collider colled)
    {
        if (colled.tag == "targ")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }   
    }
}
