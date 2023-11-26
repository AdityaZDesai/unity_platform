using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthDisplay : MonoBehaviour
{
    public int health = 20;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health : " + health;
    }

    public void decreaseHealth(int decreaseAmount){
        health -= decreaseAmount;
    }
}
