using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform respawnPoint;

        void Start()
    {
        // Get the Rigidbody component attached to this object.
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Flag")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("end game");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Harmful")
        {
            transform.position = respawnPoint.transform.position;
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
    }
}
