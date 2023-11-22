using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{   

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            // Destroy the GameObject when it collides with anything
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
