using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform respawnPoint;
    private healthDisplay logic;
    private bool hasCollided = false; // Add a boolean flag to track collision

    void Start()
    {
        GameObject healthObject = GameObject.FindGameObjectWithTag("Health");
        if (healthObject != null)
        {
            logic = healthObject.GetComponent<healthDisplay>();
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Health' found.");
        }

        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollided && collision.gameObject.tag == "Harmful") // Check the flag and tag
        {
            hasCollided = true; // Set the flag to true to prevent multiple executions

            Debug.Log("Died");
            transform.position = respawnPoint.transform.position;
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
            logic.decreaseHealth(1);
        }
    }

    // You may want to reset the flag when your player is no longer colliding with the harmful object.
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Harmful")
        {
            hasCollided = false; // Reset the flag when the collision ends
        }
    }
}
