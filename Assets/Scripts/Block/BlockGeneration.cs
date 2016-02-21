using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGeneration : MonoBehaviour {
	public Rigidbody concreteBlock;
	public Rigidbody iceBlock;
	public Rigidbody player;
	public float spawnHeight = 15;
	public float spawnDistance = 30;

	void SpawnBlock(Vector3 position) {
		if (Random.Range (0, 100) < 49) {
			Rigidbody concreteClone = (Rigidbody)Instantiate (concreteBlock, position, new Quaternion ());
			concreteClone.GetComponent<ConcreteBlockDestruction> ().player = player;
		} else {
			Rigidbody iceClone = (Rigidbody)Instantiate (iceBlock, position, new Quaternion ());
			iceClone.GetComponent<IceBlockDestruction> ().player = player;
		}
	}

	void SpawnBlock(float zposition) {
		float xpos = Random.Range (-4, 5);
		SpawnBlock (new Vector3(xpos, spawnHeight, zposition));
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float zpos = player.transform.position.z + spawnDistance;
		if (zpos - Mathf.Floor (zpos) < 0.05) {
			SpawnBlock (zpos);
		}
	}
}
