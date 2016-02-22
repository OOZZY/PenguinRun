using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {
    static int lives=3;
    public Sprite health1, health2, health3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        switch (lives)
        {
            case 3:
                GetComponent<Image>().sprite = health3;
                break;
            case 2:
                GetComponent<Image>().sprite = health2;
                break;
            case 1:
                GetComponent<Image>().sprite = health1;
                break;
            case 0:
                GetComponent<Image>().sprite = null;
                break;

        }
	
	}
    public static void Increasehealth(int ammount)
    {
        
        lives += ammount;
        
        if (lives > 3)
        {
            lives = 3;
        }
    }
    public static void Decreasehealth(int ammount)
    {
        lives -= ammount;
    }
}

