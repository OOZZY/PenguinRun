using UnityEngine;
using System.Collections;

public class WalrusMovement : MonoBehaviour {
    // 0.5 1 0.2
	public Vector3 velocity = new Vector3(0f, 0f, 0.2f);
	public Rigidbody player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = new Vector3 ();
		newPosition.x = player.transform.position.x;
		newPosition.y = 1.2f;
		newPosition.z = transform.position.z;
		newPosition += velocity;
		GetComponent<Rigidbody> ().MovePosition (newPosition);

		Quaternion newRotation = new Quaternion (0, 0, 0, 1);
		GetComponent<Rigidbody> ().MoveRotation (newRotation);

		float distance = Mathf.Abs(player.transform.position.z - transform.position.z);
		print (distance);
		if (distance > 30) {
			velocity.z = 0.4f;
		} else if (distance < 9) {
			velocity.z = 0.1f;
		} else {
			velocity.z = 0.2f;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other == player.GetComponent<Collider> ()) {
			print ("COLLISION between player and walrus");
		}
	}
}