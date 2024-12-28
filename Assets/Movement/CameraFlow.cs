using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerController; // Assign your PlayerController or XR Origin

    void Update()
    {
        if (playerController != null)
        {
            transform.position = playerController.position;
            transform.rotation = playerController.rotation;
        }
    }
}
