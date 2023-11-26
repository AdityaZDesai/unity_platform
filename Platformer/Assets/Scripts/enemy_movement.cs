using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed = 5.0f;
    private int randint = 1;
    public Rigidbody2D person;

    public GameObject enemy;

    public int health = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (health == 0) {Destroy(enemy);}
        if (randint == 1){  person.transform.Translate(Vector2.right*speed*Time.deltaTime);}
        else { person.transform.Translate(Vector2.left*speed*Time.deltaTime);}
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.name == "Wall")
        {
            Debug.Log("collided");
            //If the GameObject's name matches the one you suggest, output this message in the console
            randint = 2;
        }
        if (collision.gameObject.tag == "Harmful")
        {
            Debug.Log("spikeeee");
            //If the GameObject's name matches the one you suggest, output this message in the console
            randint = 1;
        }

        if (collision.gameObject.tag == "Bullet"){
            Debug.Log("shottt");
            health -= 5;
        }

    }


}
