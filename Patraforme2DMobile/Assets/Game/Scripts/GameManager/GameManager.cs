using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //cache
    private AudioManager audioManager;


    private void Start()
    {
        //caching
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("FREAK OUT! No AudioManager in the scene.");
        }
    }
}
