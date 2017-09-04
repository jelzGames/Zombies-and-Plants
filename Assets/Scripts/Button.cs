using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;

    private Button[] buttonArray;

    public static GameObject selectedDefender;
    private Text costText;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetComponent<Defenders>().startCost.ToString();
        print(costText.text + " " + defenderPrefab.name);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    private void OnMouseDown()
    {
        
        foreach (Button button in buttonArray)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
