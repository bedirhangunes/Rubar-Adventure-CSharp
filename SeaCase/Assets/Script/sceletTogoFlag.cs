using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class sceletTogoFlag : MonoBehaviour
{
    Animator animator;
    float menzil = 10, mesafe;
    public GameObject target;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        mesafe = Vector3.Distance(target.transform.position, transform.position);
        if (mesafe <= menzil)
        {
            agent.SetDestination(target.transform.position);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, menzil);
    }
     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "flage")
        {
            SceneManager.LoadScene("finish");
        }
    }
}
