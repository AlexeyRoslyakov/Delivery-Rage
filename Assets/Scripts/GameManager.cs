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
    public Button startButton;
    public Button quitButton;
    public Image titleScreen;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip finalCrashSound;
    public AudioClip powerupSound;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
        playerAudio = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        isGameActive = true;
        playerAudio.PlayOneShot(clickSound, 2.0f);
        titleScreen.gameObject.SetActive(false);
        player = GameObject.Find("Player");

        StartCoroutine(SpawnObjects());


        cargoCount = 10;
        cargoCountText.text = "Cargo " + cargoCount + " / 10";

    }
    public void RestartGame()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CargoCount()
    {
        Debug.Log("hit vehicle");
        playerAudio.PlayOneShot(crashSound, 1.0f);
        Instantiate(cargo);
        cargoCount--;
        cargoCountText.text = "Cargo  " + cargoCount + " / 10";
        player.GetComponent<PlayerController>().RegularCrush();
        if (cargoCount <= 0)
            
        {
            player.GetComponent<PlayerController>().FinalCrush();
            playerAudio.PlayOneShot(finalCrashSound, 1.0f);
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



}
