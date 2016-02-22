using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public static float ITEM_EFFECT_TIMER = 10.0f;
    public struct Fish
    {
        public int ammount;
        public float timer;
        public bool timerStarted;
        public Fish(int ammount, float timer)
        {
            this.ammount = ammount;
            this.timer = timer;
            this.timerStarted = false;

        }
        public void Collide()
        {
            this.timerStarted = true;
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
        //public int ammount;
        public float timer;
        public bool timerStarted;
        public Star(int ammount, float timer)
        {
            //this.ammount = ammount;
            this.timer = timer;
            this.timerStarted = false;
        }
        public void Collide()
        {
            this.timerStarted = true;
            //this.ammount += 1;
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
        public bool timerStarted;
        public FishBone(int ammount, float timer)
        {
            this.ammount = ammount;
            this.timer = timer;
            this.timerStarted = false;
        }
        public void Collide()
        {
            this.timerStarted = true;
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
    GameObject player;
    //PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    // Use this for initialization
    void Start() {
        myFish=new Fish(0,0f);
        myStar = new Star(0, 0f);
        myBone = new FishBone(0, 0f);
        player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        //update Hud Ui based on item ammounts

        //Update player based item ammounts;

        //playerMovement.SetSpeed(13);

        /*
        if (myFish.timer > 0.00f)
        {
            myFish.timer -= Time.deltaTime;
        }
        else
        {
            fishOver = true;
        }
        
        else
        {
            if (fishRun)
            {
                playerMovement.ResetSpeed();
            }
            
        }
        if (myBone.timer > 0.00f)
        {
            myBone.timer -= Time.deltaTime;
        }
        else
        {
            boneOver = true;
        }
        else
        {
            playerMovement.ResetSpeed();
        }

        if (myStar.timer > 0.00f)
        {
            myStar.timer -= Time.deltaTime;
        }
        else
        {
            starOver = true;
        }*/












        bool fishOver = false, boneOver = false, starOver = false;

        

        if (myFish.timerStarted)
        {
            if (myFish.timer > 0.0f)
            {
                myFish.timer -= Time.deltaTime;
            }
            else
            {
                fishOver = true;
                myFish.timerStarted = false;
            }
        }

        if (myBone.timerStarted)
        {
            if (myBone.timer > 0.0f)
            {
                myBone.timer -= Time.deltaTime;
            }
            else
            {
                boneOver = true;
                myBone.timerStarted = false;
            }
        }

        if (myStar.timerStarted)
        {
            if (myStar.timer > 0.0f)
            {
                myStar.timer -= Time.deltaTime;
            }
            else
            {
                starOver = true;
                myStar.timerStarted = false;
            }
        }

        if (fishOver)
        {
            playerMovement.DecreaseSpeed(3f);
        }

        if (boneOver)
        {
            playerMovement.IncreaseSpeed(3f);
        }

        if (starOver)
        {

        }
    }
    public void FishCollide()
    {
        myFish.Collide();
        playerMovement.IncreaseSpeed(3f);

    }
    public void StarCollide()
    {
        myStar.Collide();
        
    }
    public void FishBoneCollide()
    {
        myBone.Collide();
        playerMovement.DecreaseSpeed(3f);
    }
}
