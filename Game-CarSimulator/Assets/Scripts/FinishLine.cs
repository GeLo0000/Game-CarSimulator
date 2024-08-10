using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject rccCamera;
    public GameObject cameraFinish;
    public GameObject finishMenu;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar"))
        {
            RCC_CarControllerV3 carController = other.GetComponent<RCC_CarControllerV3>();
            if (carController != null)
            {
                carController.canControl = false;

                rccCamera.SetActive(false);
                cameraFinish.SetActive(true);
                finishMenu.SetActive(true);
            }
        }
    }
}
