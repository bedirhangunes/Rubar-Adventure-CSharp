using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    NavMeshAgent AgentMesh;
    Animator animat;
    public GameObject player, explosion;
    float mesafe, height = 15f;
    GameObject deadEnmy;
    GameSetting gameStting;
    void Start()
    {
        AgentMesh = GetComponent<NavMeshAgent>();
        animat = GetComponent<Animator>();
        deadEnmy = GameObject.FindGameObjectWithTag("enemy");
        gameStting = deadEnmy.GetComponent<GameSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        mesafe = Vector3.Distance(player.transform.position, transform.position);
        if (mesafe <= height)
        {
            AgentMesh.SetDestination(player.transform.position);
            animat.SetBool("shootRun", true);

        }
        else
        {
            animat.SetBool("shoorRun", false);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, height);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "targ")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }
    }
}
