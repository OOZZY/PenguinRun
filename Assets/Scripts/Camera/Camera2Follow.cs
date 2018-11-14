using UnityEngine;
using System.Collections;

public class Camera2Follow : MonoBehaviour {
	public Rigidbody player;

	// Use this for initialization
	void Start () {
		transform.rotation = new Quaternion (0, 180, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		float y = transform.position.y;
		float z = player.transform.position.z;
		transform.position = new Vector3(x, y, z);
	}
}
