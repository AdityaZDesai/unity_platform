using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{   

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 270f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Spike")
        {
            Debug.Log("end game");
            gameObject.SetActive(false);
            //If the GameObject's name matches the one you suggest, output this message in the console
        }

    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
