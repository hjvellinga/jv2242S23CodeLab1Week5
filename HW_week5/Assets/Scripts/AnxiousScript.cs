using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxiousScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.instance.GetComponent<ASCIILevelLoaderScript>().HitNPC();
        Debug.Log("this one's anxiously attached and will close in on you and give damage when it touches you");
    }
}
