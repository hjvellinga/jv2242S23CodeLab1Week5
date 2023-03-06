using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidantScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.instance.GetComponent<ASCIILevelLoaderScript>().HitNPC();
        Debug.Log(message: "This one's avoidant, looks like your goal but when player catches it, player takes damage");
    }
}
