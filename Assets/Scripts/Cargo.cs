using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour

    
{
    private Rigidbody cargoRb;
    private GameObject player;
    

    private Vector3 offset = new Vector3(0, 2f, -2.5f);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cargoRb = GetComponent<Rigidbody>();
        cargoRb.AddForce(Vector3.up * Random.Range(5, 7), ForceMode.Impulse);
        cargoRb.AddForce(Vector3.forward * Random.Range(1, 2), ForceMode.Impulse);
        cargoRb.AddTorque(Random.Range(10, 10), Random.Range(10, 10), Random.Range(10, 10), ForceMode.Impulse);
        transform.position = player.transform.position+offset;
        
    }
        
}
