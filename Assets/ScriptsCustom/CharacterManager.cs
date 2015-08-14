using UnityEngine;
//using Windows.Kinect;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text; 

public class CharacterManager : MonoBehaviour
{
    
    //created player prefab
    public GameObject playerPrefab;
    public int numCharacters = 0;
    
    private List<GameObject> characters;
    
    private static CharacterManager instance = null;
    public static CharacterManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    // Use this for initialization
    void Start()
    {
        numCharacters = 0;
        characters = new List<GameObject>();
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        KinectManager manager = KinectManager.Instance;
        
        if(numCharacters < manager.GetUsersCount())
        {
            GameObject character = Instantiate<GameObject>(playerPrefab);
            character.GetComponent<NetworkedUserController>().playerIndex = manager.GetUsersCount() - 1;
            characters.Add(character);
            
            numCharacters = manager.GetUsersCount();
            
        }
        
    }
}

