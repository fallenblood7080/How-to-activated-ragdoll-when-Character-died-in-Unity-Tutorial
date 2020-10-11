using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log($"we hit + {hit.transform.name}");
            ragdoll doRagdoll = hit.transform.GetComponent<ragdoll>();

            if (doRagdoll != null)
            {
                Debug.Log("hit!");
                doRagdoll.isRagdoll(true);
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * 100f);
                }
            }
        }
    }
}
