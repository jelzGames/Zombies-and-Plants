using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager leveleManager;

    private void Start()
    {
        leveleManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Attacker defender = collision.GetComponent<Attacker>() as Attacker;
        if (defender)
        {
            leveleManager.LoadLevel("03b Loose");
        }
    }
}
