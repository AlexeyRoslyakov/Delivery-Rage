using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawn : MonoBehaviour
{
    public GameObject[] vehiclePrefab;
    public GameObject player;
    private GameManager gameManager;

    [SerializeField] private Vector3 distanceToPlayer;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private float spawnRangeA;
    [SerializeField] private float spawnRangeB;

    [SerializeField] private float spawnDelay = 2;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private float moveDirection;
    //[SerializeField] private bool isOpposite;  //I'm sure it will come in handy in the future
    private Vector3 offset = new Vector3(0, 0.1f, 110);
    // Start is called before the first frame update
    void Start()
    {



        //InvokeRepeating("SpawnRandomVehicle", spawnDelay, spawnInterval);



    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    public void SpawnRandomVehicle()
    {
        spawnInterval = Random.Range(0.5f, 2f);
        //Get direction
        DriveDirection();

        //Select the random car
        int vehicleIndex = Random.Range(0, vehiclePrefab.Length);

        //Set direction to spawn car 
        vehiclePrefab[vehicleIndex].transform.rotation = transform.rotation = Quaternion.Euler(0, moveDirection, 0);

        // Set distance far ahead from the player 
        distanceToPlayer = transform.position = new Vector3(0, 0, player.transform.position.z) + offset;

        // Set position for spawn
        spawnPos = new Vector3(Random.Range(spawnRangeA, spawnRangeB), 0, 0) + distanceToPlayer;

        // And spawn at last
        Instantiate(vehiclePrefab[vehicleIndex], spawnPos, vehiclePrefab[vehicleIndex].transform.rotation);

        Debug.Log("Spawn Car inerval:" + spawnInterval);

    }

    void DriveDirection() // Selects in which direction the car is moving
    {
        int directionDesicion = Random.Range(0, 101);
        if (directionDesicion > 50)
        {
            moveDirection = 180;
            //isOpposite = true;
            spawnRangeA = -10.5f;
            spawnRangeB = -5;
        }
        else
        {
            moveDirection = 0;
            //isOpposite = false;
            spawnRangeA = 0;
            spawnRangeB = 5.5f;
        }
    }


}
