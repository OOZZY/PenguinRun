using UnityEngine;
using System.Collections;

public class WalrusMovement : MonoBehaviour {
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
	}

	void OnTriggerEnter(Collider other) {
		if (other == player.GetComponent<Collider> ()) {
			print ("COLLISION between player and walrus");
		}
	}
}