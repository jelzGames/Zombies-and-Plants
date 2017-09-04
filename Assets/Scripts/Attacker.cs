using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range (-1F,1.5F)]
    public float currentSpeed;

    [Tooltip("Avarage number of seconds between appearances")]
    public float seenEverySeconds;


    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        /*
        Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
        if (rigidBody)
        {
            rigidBody.isKinematic = true;
        }
        */

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }

       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void setSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Call from the animator at time of actual blow - make points
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
