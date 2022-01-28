using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int cargoCount;
    public TextMeshProUGUI cargoCountText;
    public TextMeshProUGUI failedText;
    public GameObject player;
    public GameObject cargo;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;

        player = GameObject.Find("Player");

        cargoCount = 2;
        cargoCountText.text = "Cargo " + cargoCount + " / 10";
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
        isGameActive = false;
    }
}
