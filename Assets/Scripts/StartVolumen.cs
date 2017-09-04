using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolumen : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            float volumen = 0.5f;
            if (PlayerPrefsManager.GetUserPrefs() == 1)
            {
                volumen = PlayerPrefsManager.GetMasterVolumen();
            }
            musicManager.SetVolumen(volumen);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
