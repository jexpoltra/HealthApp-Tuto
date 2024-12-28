using UnityEngine;

public class KeyboardOnlyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit der Bewegung
    public float lookSpeed = 2f; // Geschwindigkeit der Kamerarotation

    private float xRotation = 0f; // Vertikale Kamerarotation (Hoch/Runter)

    void Update()
    {
        // Bewegung mit den Pfeiltasten (vorwärts, rückwärts, links, rechts)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Pfeiltasten Links/Rechts
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // Pfeiltasten Hoch/Runter

        // Bewegung relativ zur Ausrichtung des Objekts
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move;

        // Kamera-Drehung mit WASD
        float lookX = 0f;
        float lookY = 0f;

        if (Input.GetKey(KeyCode.W))
            lookY = -1f; // Kamera nach oben drehen
        if (Input.GetKey(KeyCode.S))
            lookY = 1f; // Kamera nach unten drehen
        if (Input.GetKey(KeyCode.A))
            lookX = -1f; // Kamera nach links drehen
        if (Input.GetKey(KeyCode.D))
            lookX = 1f; // Kamera nach rechts drehen

        // Vertikale Rotation der Kamera (Hoch/Runter)
        xRotation += lookY * lookSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Begrenzung der vertikalen Rotation

        // Anwenden der Rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Vertikale Rotation
        transform.parent.Rotate(Vector3.up * lookX * lookSpeed * Time.deltaTime); // Horizontale Rotation
    }
}
