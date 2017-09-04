using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

    public int startCost = 100;
    private StarsDisplay starDisplay;
    // use only for tag

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarsDisplay>();
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
