using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    private Rigidbody soul;
    private GameObject body;


    private Vector3 offset = new Vector3(0, 2.3f, 0);
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Player");
        soul = GetComponent<Rigidbody>();
        soul.AddForce(Vector3.up * Random.Range(5, 7), ForceMode.Impulse);
        soul.AddForce(Vector3.forward * Random.Range(1, 2), ForceMode.Impulse);
        soul.AddTorque(Random.Range(10, 10), Random.Range(10, 10), Random.Range(10, 10), ForceMode.Impulse);
        transform.position = transform.position + offset;

    }
}
