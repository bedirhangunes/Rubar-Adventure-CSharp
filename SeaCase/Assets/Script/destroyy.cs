using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyy : MonoBehaviour
{
     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "bullet")
        {
            Destroy(gameObject,2);
        }
    }
}
