using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;  // vitesse de déplacement
    public float rotationSpeed = 100f; // vitesse pour tourner
    public Transform cameraTransform;
    private float xRotation = 0f;
    void Update()
    {
        // Déplacement avant/arrière
        float vertical = Input.GetAxis("Vertical"); // flèches haut/bas ou W/S
        // Déplacement gauche/droite
        float horizontal = Input.GetAxis("Horizontal"); // flèches gauche/droite ou A/D

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        transform.position += move * speed * Time.deltaTime;

        // Rotation avec la souris
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
         // Rotation verticale
        float mouseY = Input.GetAxis("Mouse Y");
        xRotation -= mouseY * rotationSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    
    
    
    }
}
