using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoCounter : MonoBehaviour
{
    public GameObject[] cargo;
    private int cargoCount;
    private int cargoLoaded;
    // Start is called before the first frame update
    void Start()
    {
        cargoLoaded = 10;
        cargoCount = cargoLoaded;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CargoCount()
    {

        int cargoIndex = Random.Range(0, cargo.Length);
                Instantiate(cargo[cargoIndex]);
        cargoCount--;
        /*cargoCountText.text = "Cargo  " + cargoCount + " / "+ cargoLoaded;
                if (cargoCount <= 0)

        {
            
            LevelFailed();
        }*/
    }
}
