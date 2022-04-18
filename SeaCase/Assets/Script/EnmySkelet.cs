using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnmySkelet : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    public GameObject patlama;
    float mesafe, menzil = 10f;
    NavMeshAgent meshAgent;
    GameSetting gameSett;
    GameObject score;
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        score = GameObject.FindGameObjectWithTag("enemy");
        gameSett = score.GetComponent<GameSetting>();
        
    }

   
    void Update()
    {
        mesafe = Vector3.Distance(player.transform.position, transform.position);
        if (mesafe <= menzil)
        {
            meshAgent.SetDestination(player.transform.position);
            animator.SetBool("Shoot", true);
        }
        else
        {
            animator.SetBool("Shoot", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, menzil);

    }
     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "targ")
        {
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            gameSett.scorePlus(1);
        }
    
    }
}
