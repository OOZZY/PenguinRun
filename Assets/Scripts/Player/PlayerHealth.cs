﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int startingHealth = 3;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    //public Slider healthSlider;                                 // Reference to the UI's health bar.
    //public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    //int startingIce; // The players Starting ammount of ice.
    //int currentIce; // The players current ammount pf ice

    bool isDead;                                                // Whether the player is dead.
    bool damaged;
    bool collideWithIce;
    bool collideWithBlock;
    bool colideWithItem;
    public bool invanurableState;           

    // Use this for initialization
    void Awake () {
		currentHealth = startingHealth;
       //currentHealth = startingIce;
	
	}
	
	// Update is called once per frame
	void Update () {

        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            //damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;

    }
    public void TakeDamage(int ammount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= ammount;
        HealthManager.Decreasehealth(ammount);
        // Set the health bar's value to the current health.
        //healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...

        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
		currentHealth = startingHealth;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("GameStart");
    }
    public void IncreaseHealth(int ammount)
    {
        currentHealth = currentHealth + ammount;
        HealthManager.Increasehealth(ammount);

    }
    // The ammount of ice that the player has to throw some back
    /*
    public void IncreaseIce()
    {
        if (currentIce < 5)
        {
            currentIce += 1;
        }
    }
    public void DecreaseIce()
    {
        currentIce -= 1;
    }

    // State thw player is in
    */

	public void EnableinvanurableState()
	{
		invanurableState = true;
	}
	public void DisableinvanurableState()
	{
		invanurableState = false;
	}
	public bool isInvulnurable() {
		return invanurableState;
	}

}
