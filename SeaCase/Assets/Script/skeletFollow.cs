using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class skeletFollow : MonoBehaviour
{
    Animator animator;
    float menzil=5,mesafe;
 public GameObject target;
    NavMeshAgent agentmesh;
    void Start()
    {
        agentmesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        mesafe = Vector3.Distance(target.transform.position, transform.position);
        if (mesafe <= menzil)
        {
            agentmesh.SetDestination(target.transform.position);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, menzil);
    }
}
