using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxDistance = 5.0f;
    public float baseRotationSpeed = 5.0f;
    public GameObject bullet;
    public Transform gunTransform; // Reference to the transform of the gun.

    public GameObject audioPrefab;
    public Transform gun_pivot;

    // Maximum distance for full rotation speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePos = Input.mousePosition;
        
        // Convert the mouse position to a point in the game world
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f)); // 10.0f is the distance from the camera

        // Calculate the direction from the gun to the mouse position
        Vector3 direction = mousePos - gun_pivot.position;
        direction.z = 0; // Make sure the gun doesn't rotate in the z-axis

        // Calculate the angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Calculate the rotation speed based on the distance
        float distance = direction.magnitude;
        float rotationSpeed = baseRotationSpeed * (1.0f - Mathf.Clamp01(distance / maxDistance));

        // Rotate the gun towards the mouse position smoothly
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    

        if (Input.GetMouseButtonDown(0))
        {   
            GameObject soundObject = Instantiate(audioPrefab, gunTransform.position, Quaternion.identity);
            AudioSource audioSource = soundObject.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.volume = 0.25f; // Adjust volume
                audioSource.playOnAwake = false; 
                
                // Play the sound.
                audioSource.Play();
            }
            Quaternion currentRotation = gunTransform.rotation;

            // Add 270 degrees to the current rotation
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 270);

            // Use the gun's position as the spawn point.
            Vector2 spawnPosition = gunTransform.position;

            // Create the bullet at the spawn position with the gun's rotation.
            GameObject g = Instantiate(bullet, spawnPosition, newRotation);
            g.SetActive(true);
        }
    }
}
