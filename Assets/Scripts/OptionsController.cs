using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumenSlider, difficultySlider;
    public LevelManager levelManager;
    

    private MusicManager musicMnager;

	// Use this for initialization
	void Start () {

        musicMnager = GameObject.FindObjectOfType<MusicManager>();
        if (PlayerPrefsManager.GetUserPrefs() == 1) {
            volumenSlider.value = PlayerPrefsManager.GetMasterVolumen();
            difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        }
        else
        {
            SetDeafults();
        }


    }
	
	// Update is called once per frame
	void Update () {
        musicMnager.SetVolumen(volumenSlider.value);

    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetUserPrefs();
        PlayerPrefsManager.SetMasterVolumen(volumenSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01a Start Menu");
    }

    public void SetDeafults()
    {
        volumenSlider.value = 0.5f;
        difficultySlider.value = 2f;
    }
}
