using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;
    private StarsDisplay starDisplay;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarsDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPositionMOuseClick();
        Vector2 roundPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defenders>().startCost;
        if (starDisplay.UseStars(defenderCost) == StarsDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundPos, defender);
        }
    }

    void SpawnDefender(Vector2 roundPos, GameObject defender)
    {
        Quaternion zeroRotation = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, roundPos, zeroRotation) as GameObject;
        newDefender.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float x = Mathf.RoundToInt(rawWorldPos.x);
        float y = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(x,y);
    }

    Vector2 CalculateWorldPositionMOuseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        // distance doesnot matter you can put whatever value 
        float distanceFromCamera = 10f;

        // one point in the camera
        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        //world position
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
