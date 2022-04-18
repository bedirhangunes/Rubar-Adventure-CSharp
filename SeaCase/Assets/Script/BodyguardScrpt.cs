using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BodyguardScrpt : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    float menzil = 10f, mesafe;
    public GameObject hedef, patlama;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        mesafe = Vector3.Distance(hedef.transform.position, transform.position);
        if (mesafe <= menzil)
        {
            agent.SetDestination(hedef.transform.position);
            animator.SetBool("attacku",true);
        }
        else
        {
            animator.SetBool("attacku", false);
            Debug.Log("animation is stop");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, menzil);
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
