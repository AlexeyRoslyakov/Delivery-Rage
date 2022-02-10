using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    //public Animator animator;
    public List<Collider> RagdollParts = new List<Collider>();
    private Rigidbody rigidBody;
    private float speed_f;
    private Animator dummyAnim;

    private void Awake()
    {
        SetRagdollParts();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        dummyAnim = GetComponent<Animator>();
    }


    private void SetRagdollParts()

    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {

            if (c.gameObject != this.gameObject)
            {
                c.isTrigger = true;
                RagdollParts.Add(c);
            }
        }
    }
    public void TurnOnRagdoll()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        foreach (Collider c in RagdollParts)
        {
            c.isTrigger = false;
            //c.attachedRigidbody.velocity = flyAway;
        }

    }
    IEnumerator WaitForDeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            TurnOnRagdoll();

        }
    }

}
