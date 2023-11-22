using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Spike")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        if (collision.gameObject.name == "Flag")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("end game");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Respawn")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}
