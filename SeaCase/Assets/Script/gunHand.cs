using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class gunHand : MonoBehaviour
{
    RaycastHit hit;
    public Rigidbody bull;
    public Transform target;
    public float impul = 2000.0f;
    float fire = 0;
    bool fireControl = false;

    void Start()
    {
        
    }

    void Update()
    {
     //   rayDrawing();
        if (Input.GetMouseButton(0))
        {
            fire += Time.deltaTime;
            if (fire > 0.35f)
            {
                Rigidbody bullet = (Rigidbody)Instantiate(bull, target.position + target.forward, target.rotation);
                bullet.AddForce(target.forward * impul, ForceMode.Impulse);
                fire = 0;
            }
            fireControl = true;
        }
    }
    void rayDrawing()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log("goal");
        }
        else
        {
            Debug.Log("try again");
        }
        Debug.DrawRay(ray.origin, ray.GetPoint(1500));
        Debug.DrawLine(target.transform.position, hit.point, Color.blue);
    }
}
