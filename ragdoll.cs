using System;
using System.Collections;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    public Collider mainCollider; //capsules collider
    public Collider[] col; // collider that are in child objects Ex - hips,spine etc..
    public Animator animator;//Animator commponent
    public Rigidbody[] rb; //rigidbody compoments that are in child object ex -hips,spine etc. 
    
    private void Awake() //Execute before the game start
    {
        isRagdoll(false);
    }

    public void isRagdoll(bool isragdoll)//give one bool parameter and make sure it is public
    {
        if (isragdoll == false) // when character is playing some animtion or alive
        {

            animator.enabled = true; //play animations
            mainCollider.enabled = true;//capsules is enable
            for (int i = 0; i < col.Length; i++)
            {
                Physics.IgnoreCollision(col[i], mainCollider);//prevent the collision btw two collider[this is important]
            }
        }
        else//when characte died
        {
            mainCollider.enabled = false;//disable the capsule collider
            animator.enabled = false; // stop playing animation

            for (int i = 0; i < col.Length; i++)
            {
                Physics.IgnoreCollision(mainCollider, col[i]);//prevent the collision btw two collider[this is important]
            }
            StartCoroutine(disableCollider()); //disabling child colliders
        }
    }
    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(3.5f); // wait for some time to disable collider
        for (int i = 0; i < col.Length; i++)
        {
            rb[i].useGravity= false;//disable gravity
            col[i].enabled = false;//disable child colliders
        }
    }
}
