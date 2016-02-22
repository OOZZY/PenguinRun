using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public static float ITEM_EFFECT_TIMER = 10.0f;
    public struct Fish
    {
        public int ammount;
        public float timer;
        public Fish(int ammount, float timer)
        {
            this.ammount = ammount;
            this.timer = timer;

        }
        public void Collide()
        {
            this.ammount += ammount;
            if(this.timer+ ITEM_EFFECT_TIMER < 15)
            {
                timer += ITEM_EFFECT_TIMER;
            }
            else
            {
                timer = ITEM_EFFECT_TIMER;
            }
            

        }

    }
    public struct Star
    {
        public int ammount;
        public float timer;
        public Star(int ammount, float timer)
        {
            this.ammount = ammount;
            this.timer = timer;
        }
        public void Collide()
        {
            this.ammount += 1;
            if (this.timer + ITEM_EFFECT_TIMER < 15)
            {
                timer += ITEM_EFFECT_TIMER;
            }
            else
            {
                timer = ITEM_EFFECT_TIMER;
            }

        }

    }
    public struct FishBone
    {
        public int ammount;
        public float timer;
        public FishBone(int ammount, float timer)
        {
            this.ammount = ammount;
            this.timer = timer;
        }
        public void Collide()
        {
            this.ammount += ammount;
            if (this.timer + ITEM_EFFECT_TIMER < 15)
            {
                timer += ITEM_EFFECT_TIMER;
            }
            else
            {
                timer = ITEM_EFFECT_TIMER;
            }

        }

    }
    public struct Icicle
    {
        public int ammount;
        public float damage;
        Icicle(int ammount, float damage)
        {
            this.ammount = ammount;
            this.damage = damage;
        }
        public void Collide()
        {
            this.ammount += 1;
        }
        public void DecreaseIcicle()
        {
            this.ammount -= 1;
        }

    }
    public Fish myFish;
    public Star myStar;
    public FishBone myBone;
    public GameObject player;
    //PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    // Use this for initialization
    void Start() {
        myFish=new Fish(0,0);
        myStar = new Star(0, 0f);
        myBone = new FishBone(0, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {
        //update Hud Ui based on item ammounts

        //Update player based item ammounts;

        //playerMovement.SetSpeed(13);
        if (myStar.timer>0.00f)
        {
            myStar.timer -= Time.deltaTime;
        }
        else
        {
            playerMovement.ResetSpeed();
        }
        

    }
    public void FishCollide()
    {
        myFish.Collide();
    }
    public void StarCollide()
    {
        myStar.Collide();
        playerMovement.SetSpeed(13f);
    }
    public void FishBoneCollide()
    {
        myBone.Collide();
    }
}
