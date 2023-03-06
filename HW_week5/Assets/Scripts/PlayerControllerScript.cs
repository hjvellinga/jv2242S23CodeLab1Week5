using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float forceAmount = 2; 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //if button W is pressed
        {
            rb2d.AddForce(forceAmount * Vector2.up); //add force amount upwards onto player rigidbody
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(forceAmount *Vector2.down);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(forceAmount * Vector2.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(forceAmount * Vector2.right);
        }
        
    }
}
