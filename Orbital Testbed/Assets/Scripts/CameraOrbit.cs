using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float sensitivity = 3f;
    public float minY = -80f;
    public float maxY = 80f;

    float rotX = 0f;
    float rotY = 0f;
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotX = angles.y;
        rotY = angles.x;
    }
 
    void LateUpdate()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * 5f;
        distance = Mathf.Clamp(distance, 7f, 100f);
        if (Input.GetMouseButton(1))
        {
            rotX += Input.GetAxis("Mouse X") * sensitivity;
            rotY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotY = Mathf.Clamp(rotY, minY, maxY);
        }

        Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        transform.position = target.position + rotation * negDistance;

        transform.LookAt(target);
    }
}
