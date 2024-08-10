using UnityEngine;

public class CarSwitcher : MonoBehaviour
{
    public Transform[] cars; // Масив з усіма машинами
    private int currentCarIndex = 0;
    public CameraController cameraController;

    void Start()
    {
        if (cars.Length > 0)
        {
            SetActiveCar(currentCarIndex);
        }
    }

    public void NextCar()
    {
        currentCarIndex = (currentCarIndex + 1) % cars.Length;
        SetActiveCar(currentCarIndex);
    }

    public void PreviousCar()
    {
        currentCarIndex = (currentCarIndex - 1 + cars.Length) % cars.Length;
        SetActiveCar(currentCarIndex);
    }

    void SetActiveCar(int index)
    {
        PlayerPrefs.SetInt("SelectedCarIndex", index);
        PlayerPrefs.Save(); // Зберегти вибраний автомобіль
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].gameObject.SetActive(i == index);
        }
        cameraController.SetTarget(cars[index]);
    }
}
