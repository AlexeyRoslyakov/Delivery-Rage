using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int cargoCount;
    private int spawnRate = 1;
    public TextMeshProUGUI cargoCountText;
    public TextMeshProUGUI failedText;
    public GameObject player;
    public GameObject vehicleSpawner;
    public GameObject cargo;
    public bool isGameActive;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;

        player = GameObject.Find("Player");

        StartCoroutine(SpawnObjects());


        cargoCount = 2;
        cargoCountText.text = "Cargo " + cargoCount + " / 10";

        //StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CargoCount()
    {
        Debug.Log("hit vehicle");
        Instantiate(cargo);
        cargoCount--;
        cargoCountText.text = "Cargo " + cargoCount + " / 10";
        if (cargoCount <= 0)
        {
            LevelFailed();
        }

    }
    public void LevelFailed()
    {
        failedText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        vehicleSpawner.gameObject.SetActive(false);
    }

    IEnumerator SpawnObjects()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
               vehicleSpawner.GetComponent<VehicleSpawn>().SpawnRandomVehicle();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
