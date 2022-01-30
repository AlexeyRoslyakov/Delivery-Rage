using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos;
    private Vector3 stepForward;
    private float sideLeftPos;
    private float sideRightPos;
    private float alongRoadPos;
    public int length = 80;
       
    private Quaternion spawnRot;
    // Start is called before the first frame update
    void Start()
    {
        
        
        

        for (int i = 0; i < length; i++)
        {


            SpawnObstaclesRight();
            SpawnObstaclesLeft();
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
           
        }
    }
    public void SpawnObstaclesLeft()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        spawnRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
        sideLeftPos =  Random.Range(-28, -12);  
        
        alongRoadPos = Random.Range(5, 1800);
        spawnPos = new Vector3(sideLeftPos, 0, alongRoadPos);

        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, spawnRot);

    }public void SpawnObstaclesRight()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        spawnRot = Quaternion.Euler(0, Random.Range(0, 360), 0);        
        sideRightPos = Random.Range(12, 28);
        
        alongRoadPos = Random.Range(5, 1800);
        spawnPos = new Vector3(sideRightPos, 0, alongRoadPos);

        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, spawnRot);

    }
}
