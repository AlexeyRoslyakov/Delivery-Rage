using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int cargoCount;
    //private int spawnRate = 1;
    public TextMeshProUGUI cargoCountText;
    public TextMeshProUGUI failedText;
    public TextMeshProUGUI deliveredText;
    public GameObject player;
    public GameObject vehicleSpawner;
    public GameObject[] cargo;
    public GameObject levelLoader;
    public bool isGameActive;
    public Button restartButton;
    public Button startButton;
    public Button quitButton;
    public Button nextLevelButton;
    public Image titleScreen;
    public Image passedScreen;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip finalCrashSound;
    public AudioClip powerupSound;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader.gameObject.SetActive(true);
        playerAudio = GetComponent<AudioSource>();
        StartGame();
    }
    public void StartGame()
    {
        // start fade or not at least???
        //levelLoader.GetComponent<LevelLoader>().NextScreen();

        isGameActive = true;
        
        //playerAudio.PlayOneShot(clickSound, 2.0f);

        player = GameObject.Find("Player");

        vehicleSpawner.gameObject.SetActive(true);

        cargoCountText.gameObject.SetActive(true);
        cargoCount = 10;
        cargoCountText.text = "Cargo " + cargoCount + " / 10";

    }
    public void CargoCount()
    {
        int cargoIndex = Random.Range(0, cargo.Length);
        playerAudio.PlayOneShot(crashSound, 1.0f);
        Instantiate(cargo[cargoIndex]);
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
    public void RestartGame()
    {
        // start fade or not at least???
        levelLoader.GetComponent<LevelLoader>().NextScreen();


        playerAudio.PlayOneShot(clickSound, 2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        Application.Quit();

    }

    public void LevelFailed()
    {
        // start fade or not at least???
        levelLoader.GetComponent<LevelLoader>().NextScreen();


        failedText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        vehicleSpawner.gameObject.SetActive(false);
    }
    public void LevelPassed()
    {
        // start fade or not at least???


        cargoCountText.gameObject.SetActive(false);
        passedScreen.gameObject.SetActive(true);
        deliveredText.text = "You were only able to deliver " + cargoCount + " boxes";
        isGameActive = false;
        vehicleSpawner.gameObject.SetActive(false);
    }


    /*IEnumerator SpawnObjects()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            vehicleSpawner.GetComponent<VehicleSpawn>().SpawnRandomVehicle();
        }
    }*/

    public void LevelRotation()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        //SceneManager.LoadScene("DR Scene2", LoadSceneMode.Single);
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();

    }
    public void ToMenuGame()
    {
        playerAudio.PlayOneShot(clickSound, 2.0f);
        SceneManager.LoadScene(0);

    }


}
