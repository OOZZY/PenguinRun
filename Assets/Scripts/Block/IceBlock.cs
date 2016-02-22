using UnityEngine;
using System.Collections;

public class IceBlock : MonoBehaviour {
	public enum Item {NONE, FISH, FISH_BONE, HEART, SKULL, STAR};
	public Item item;

    public float sinkSpeed = 2.5f;
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the block is hit.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    GameObject myItems;
    ItemManager itemManager;
    GameObject player;
    GameObject Ice;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    BoxCollider boxParent;
    BoxCollider[] boxes;
    bool playerCollide=false;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        boxParent = GetComponent<BoxCollider>();
        boxes = GetComponentsInChildren<BoxCollider>();
        myItems= GameObject.FindGameObjectWithTag("ItemManager");
        itemManager = myItems.GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollide)
        {
            switch (item)
            {
                case Item.NONE:

                    break;
                case Item.FISH:

                    break;
                case Item.FISH_BONE:

                    break;
                case Item.HEART:

                    break;
                case Item.SKULL:

                    break;

                case Item.STAR:
                    itemManager.StarCollide();
                    break;
                default:
                    break;
                
            }
            playerCollide = false;

        }


    }
    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            foreach (var box in boxes)
            {
                box.isTrigger = true;
            }
            playerCollide = true;
 
            //playerMovement.IncreaseSpeed((float)+2);
        }
    }
    /*
    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerCollide = false;
            
        }
    }
    */
}
