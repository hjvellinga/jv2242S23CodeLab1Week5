using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO; 

public class ASCIILevelLoaderScript : MonoBehaviour
{
    private int currentLevel = 0;

    public int CurrentLevel
    {
        get
        {
            return currentLevel; 
        }
        set
        {
            currentLevel = value;
            LoadLevel(); 
        }
    }
//create the information location
    private const string FILE_NAME = "LevelNum.txt";
    private const string FILE_DIR = "/Levels/";
    private string FILE_PATH; //creating the path from where unity can read the level files
    
    //put the gameObjects that will feature in the levels here 

    public GameObject playerCharacter;

    public GameObject goal;

    public GameObject avoidantNPC;

    public GameObject anxiousNPC;

    private GameObject level;
    public GameObject currentPlayer; //notsureyet
    
    //set some floats for the offset 
    public float xOffset;
    public float yOffset; 
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME; //once scene is loaded look here for info Unity! 
        LoadLevel(); 

    }

    bool LoadLevel()  //this is gonna be where we read information from the text documents 
    {   
        //if there's a level already, destroy it
        Destroy(level);

        level = new GameObject(name: "Level");
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");
        
      
        return false; 
    }

    public void ReachGoal()
    {
        Debug.Log(message:"Goal reached");
    }
}
