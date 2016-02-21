using UnityEngine;
using System.Collections;

public class IceBlockDestruction : MonoBehaviour {
	public Rigidbody player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.z > transform.position.z) {
			Destroy(gameObject);
		}
	}
}
