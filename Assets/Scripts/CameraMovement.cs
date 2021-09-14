using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.15f;
    public Vector3 cameraOffset;
    public bool isDead = false;


    private void LateUpdate()
    {
        if (isDead)
        {
            StopFollow();
        }
        else
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector3 Position = target.position + cameraOffset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, Position, smoothSpeed);
        transform.position = smoothPosition;
    }

    private void StopFollow()
    {
        transform.position = transform.position;
    }
}
