using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera cam; // reference for camera
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//taking inputs[Fire1 - left mouseButton]
        {
            Shoot();//call the shoot method
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log($"we hit + {hit.transform.name}");
            ragdoll doRagdoll = hit.transform.GetComponent<ragdoll>();//finding radgoll script

            if (doRagdoll != null)
            {
                Debug.Log("hit!");
                doRagdoll.isRagdoll(true);//call the isRagdoll method the give the value true
                if(hit.rigidbody != null)
                {   
                    hit.rigidbody.AddForce(-hit.normal * 100f);//add some force in backward direcction
                }
            }
        }
    }
}
