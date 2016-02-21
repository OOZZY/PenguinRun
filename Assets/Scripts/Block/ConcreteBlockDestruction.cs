using UnityEngine;
using System.Collections;

public class ConcreteBlockDestruction : MonoBehaviour {
	public Rigidbody player;
	bool timerStarted = false;
	float timeLeft = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.z > transform.position.z) {
			timerStarted = true;
		}
		if (timerStarted) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				Destroy (gameObject);
			}
		}
	}
}
