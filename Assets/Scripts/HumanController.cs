using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanController : MonoBehaviour
{
    //public Animator animator;
    private Rigidbody rigidBody;
    private float speed_f;
    private Animator dummyAnim;
    public GameObject[] scull;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        dummyAnim = GetComponent<Animator>();


        // get random interger for idle state or run
        speed_f = Random.Range(0, 2);
        int idleAnim = Random.Range(0, 10);

        // set start pose
        dummyAnim.SetInteger("Animation_int", idleAnim);
        dummyAnim.SetFloat("Speed_f", speed_f);

    }

    private void Dying()
    {
        if(isDead == false)
        {
            int scullIndex = Random.Range(0, scull.Length);
            Instantiate(scull[scullIndex], transform.position, transform.rotation);
            isDead = true;
        }
         
    }


    private void OnCollisionEnter(Collision collision)
    {
        //When people hit  vehicle or player - turn dead animation
        if (collision.gameObject.CompareTag("Vehicle") | collision.gameObject.CompareTag("Player"))
        {
            int scullIndex = Random.Range(0, scull.Length);
            // first step - jump
            dummyAnim.SetTrigger("Jump_trig");
            rigidBody.AddRelativeForce((Vector3.up * 100f), ForceMode.Impulse);
            StartCoroutine(WaitForAnimDeath());
            Dying();

            
            

        }

    }

    IEnumerator WaitForAnimDeath()
    {
        yield return new WaitForSeconds(0.5f);
        int deathType = 1;// only this type is fitted so far
        dummyAnim.SetBool("Death_b", true);
        dummyAnim.SetInteger("DeathType_int", deathType);

        if (deathType == 1)
        {
            GetComponent<BoxCollider>().center = new Vector3(0, 0.5f, -1.8f);
            GetComponent<BoxCollider>().size = new Vector3(1, 1, 3);
        }
        /*if (deathType == 2)
        {
            GetComponent<BoxCollider>().center = new Vector3(-0.2f, 0.25f, 0.3f);
            GetComponent<BoxCollider>().size = new Vector3(2f, 1f, 3f);
        }*/

    }

}
