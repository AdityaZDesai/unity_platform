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
    private Vector3 mouse_pos;
    public Transform target;
    private Vector3 object_pos;
    private float angle;

    // Maximum distance for full rotation speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen coordinates
            mouse_pos = Input.mousePosition;
            mouse_pos.z = 0;
            object_pos = Camera.main.WorldToScreenPoint(target.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

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
