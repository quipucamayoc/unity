using UnityEngine;
//using Windows.Kinect;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text; 

public class characterManager : MonoBehaviour
{

    //created player prefab
    public GameObject playerPrefab;
    private int numCharacters = 0;

    private List<GameObject> characters;

    // Use this for initialization
    void Start()
    {
        numCharacters = KinectManager.Instance.GetUsersCount();
        characters = new List<GameObject>();
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

        if(numCharacters > manager.GetUsersCount())
        {

        }

    }
}
