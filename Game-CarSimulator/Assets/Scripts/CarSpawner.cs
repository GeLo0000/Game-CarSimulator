using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs; // Масив префабів автомобілів
    private GameObject activeCar;

    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedCarIndex"))
        {
            int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex");
            if (selectedCarIndex >= 0 && selectedCarIndex < carPrefabs.Length)
            {
                activeCar = Instantiate(carPrefabs[selectedCarIndex], transform.position, transform.rotation);
            }
            else
            {
                Debug.LogError("Invalid car index!");
            }
        }
        else
        {
            Debug.LogError("No car selected!");
        }
    }
}
