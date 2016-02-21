using UnityEngine;
using System.Collections;

public class ConcreteBlock : MonoBehaviour {
    public float sinkSpeed = 2.5f;
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the block is hit.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.

    GameObject player;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    bool playerCollide;
    // Use this for initialization
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() {
        if (playerCollide)
        {
            

        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerCollide = true;
            playerMovement.DecreaseSpeed((float)-2);

        }
    }
    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            //playerCollide = false;
            playerMovement.ResetSpeed();
        }
    }
}
