using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStop : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    {
        levelManager.LoadLevel("03b Loose");
    }
}
