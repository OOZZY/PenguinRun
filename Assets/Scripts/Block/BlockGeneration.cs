using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGeneration : MonoBehaviour {
	public Rigidbody concreteBlock;
	public Rigidbody iceBlock;
	public Rigidbody player;
	public float spawnHeight = 15;
	public float spawnDistance = 30;
	public Transform fish;
	public Transform fishBone;
	public Transform heart;
	public Transform skull;
	public Transform star;

	void SpawnBlock(Vector3 position) {
		if (Random.Range (0, 100) < 50) {
			Rigidbody concreteClone = (Rigidbody)Instantiate (concreteBlock, position, new Quaternion ());
			concreteClone.GetComponent<ConcreteBlockDestruction> ().player = player;
		} else {
			Rigidbody iceClone = (Rigidbody)Instantiate (iceBlock, position, new Quaternion (0, 0, 0, 1));
			iceClone.GetComponent<IceBlockDestruction> ().player = player;

			float num = Random.Range (0, 100);
			Transform toBeCloned = null;
			IceBlock.Item item = IceBlock.Item.NONE;
			Quaternion newQuaternion = new Quaternion (0, 0, 0, 1);
			if (num < 50) {
			} else if (num < 60) {
				toBeCloned = fish;
				item = IceBlock.Item.FISH;
			} else if (num < 70) {
				toBeCloned = fishBone;
				item = IceBlock.Item.FISH_BONE;
			} else if (num < 80) {
				toBeCloned = heart;
				item = IceBlock.Item.HEART;
			} else if (num < 90) {
				toBeCloned = skull;
				item = IceBlock.Item.SKULL;
				newQuaternion.y = -180;
			} else if (num < 100) {
				toBeCloned = star;
				item = IceBlock.Item.STAR;
			}

			if (toBeCloned != null) {
				Transform child = (Transform)Instantiate (toBeCloned, position, newQuaternion);
				child.parent = iceClone.GetComponent<Transform> ();
			}

			iceClone.GetComponent<IceBlock> ().item = item;
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
