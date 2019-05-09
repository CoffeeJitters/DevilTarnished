using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    public Transform lookAt;
    public Transform camTransform;
    public Transform Pivot;

    private Camera cam;

    public float distance;
    public float currentX;//was 0
    public float currentY;//was 0
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    void start()
    {
        camTransform = transform;
        cam = Camera.main;
        Pivot.transform.position = lookAt.transform.position;
        Pivot.transform.parent = lookAt.transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
