using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "targ")
        {
            Destroy(gameObject);
        }
    }
}
