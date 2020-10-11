using System;
using System.Collections;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    public Collider mainCollider;
    public Collider[] col;
    public Animator animator;
    public Rigidbody[] rb;
    private void Awake()
    {
        isRagdoll(false);
    }

    public void isRagdoll(bool isragdoll)
    {
        if (isragdoll == false)
        {

            animator.enabled = true;
            mainCollider.enabled = true;
            for (int i = 0; i < col.Length; i++)
            {
                Physics.IgnoreCollision(col[i], mainCollider);
            }
        }
        else
        {
            mainCollider.enabled = false;
            animator.enabled = false;

            for (int i = 0; i < col.Length; i++)
            {
                Physics.IgnoreCollision(mainCollider, col[i]);
            }
            StartCoroutine(disableCollider());
        }
    }
    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < col.Length; i++)
        {
            rb[i].useGravity= false;
            col[i].enabled = false;
        }
    }
}
