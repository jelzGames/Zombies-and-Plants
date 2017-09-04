using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
	}

    bool isTimeToSpawn(GameObject attacker)
    {
        Attacker myAttacker = attacker.GetComponent<Attacker>();
        float meanSpawnDelay = myAttacker.seenEverySeconds;
        float spawnPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnPerSecond * Time.deltaTime / 5; // 5 means lines in the grid

        if (Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Spawn(GameObject attacker)
    {
        GameObject myAttacker = Instantiate(attacker) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;

    }
}
