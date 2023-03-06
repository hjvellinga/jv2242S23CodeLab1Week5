using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    public GameObject wall; 

    private GameObject level;
    public GameObject currentPlayer; //notsureyet
    
    //set some floats for the offset 
    public float xOffset;
    public float yOffset; 
    
    //set player start position 
    public Vector2 playerStartPos; 
    
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

        string[] fileLines = File.ReadAllLines(newPath); //what's happening here exactly? the []?

        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            string lineText = fileLines[yPos];
       
        //split string up in characters (chars)

        char[] lineChars = lineText.ToCharArray();
        for (int xPos = 0; xPos < lineChars.Length; xPos++)
        {
            char
                c = lineChars[
                    xPos];  //set a generic placeholder variable for the characters, which we will alter in switch function

            GameObject newObj = null; //standard gameobject is not set 

            switch (c) //switch function that can change the c variable! 
            {
                case 'p': //when there's a p character in the text file; characters are in single quotation marks
                    playerStartPos = new Vector2(xOffset + xPos, yOffset - yPos);
                    newObj = Instantiate<GameObject>(playerCharacter);
                    currentPlayer = newObj;
                    break; 
                case '&':
                    newObj = Instantiate<GameObject>(anxiousNPC);
                    break; 
                case '!':
                    newObj = Instantiate<GameObject>(avoidantNPC);
                    break; 
                case 'g': newObj = Instantiate<GameObject>(goal);
                    break;
                case 'w': newObj = Instantiate<GameObject>(wall);
                    break;
            }

            if (newObj != null) //include the offset to all the objects in the level
            {
                newObj.transform.position =
                    new Vector2(xOffset + xPos, 
                        yOffset - yPos);

                newObj.transform.parent = level.transform; //not sure what this is??
            }
        }
        }
        return false; 
    }

    public void ReachGoal()
    {
        Debug.Log(message:"Goal reached");
        CurrentLevel++; 
    }

    public void HitNPC()
    {
        Debug.Log("ya hit someone");
    }
}
