using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWithBul : MonoBehaviour
{
    managerGame manager;
    GameObject controll;
    public GameObject explos;
    private void Start()
    {
        controll = GameObject.FindGameObjectWithTag("gmanager");

        manager = controll.GetComponent<managerGame>();

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explos, transform.position, transform.rotation);
            manager.scoreWrite(1);
        }
    }
}
