using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;
    private Slider slider;

    private AudioSource audioSource;
    private bool isEndOfLevel = false;

    private LevelManager levelManager;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("You Win");
        winLabel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if (timeIsUp && !isEndOfLevel)
        {
            HandleWinCondition();
        } 
    }

    void HandleWinCondition()
    {
        DestroyAllTagObjetcs();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTagObjetcs()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach (GameObject obj in taggedObjectArray)
        {
            Destroy(obj);
        }
    }


    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
