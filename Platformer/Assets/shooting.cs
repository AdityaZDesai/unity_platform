using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject bullet;
    public Transform gunTransform; // Reference to the transform of the gun.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion currentRotation = gunTransform.rotation;

            // Add 270 degrees to the current rotation
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 270);

            // Use the gun's position as the spawn point.
            Vector2 spawnPosition = gunTransform.position ;

            // Create the bullet at the spawn position with the gun's rotation.
            GameObject g = Instantiate(bullet, spawnPosition, newRotation);
            g.SetActive(true);
        }
    }
}
