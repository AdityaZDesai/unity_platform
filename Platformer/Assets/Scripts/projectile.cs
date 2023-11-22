using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{   

    public float speed = 5.0f;
    public ParticleSystem particlePrefab;
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
            TriggerParticleEffect();
        }

    }

    void TriggerParticleEffect()
{
    // Check if the Particle System reference is not null.
    if (particlePrefab != null)
    {
        Debug.Log("end game");
        Instantiate(particlePrefab, transform.position, Quaternion.identity);

    }
}

    // Update is called once per frame
    void Update()
    {   
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    
}
