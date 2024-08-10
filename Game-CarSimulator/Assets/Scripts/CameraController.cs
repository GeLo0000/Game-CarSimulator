using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Поточна активна машина
    public float distance = 4.0f;
    public float xSpeed = 10.0f;
    public float ySpeed = 10.0f;
    public float yMinLimit = 5f;
    public float yMaxLimit = 80f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    x += touch.deltaPosition.x * xSpeed * 0.02f;
                    y -= touch.deltaPosition.y * ySpeed * 0.02f;

                    y = ClampAngle(y, yMinLimit, yMaxLimit);
                }
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
