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
			Rigidbody concreteBlockClone = (Rigidbody)Instantiate (concreteBlock, position, new Quaternion ());
			concreteBlockClone.GetComponent<ConcreteBlockDestruction> ().player = player;
		} else {
			Rigidbody iceBlockClone = (Rigidbody)Instantiate (iceBlock, position, new Quaternion (0, 0, 0, 1));
			iceBlockClone.GetComponent<IceBlockDestruction> ().player = player;

			float num = Random.Range (0, 100);
			Transform child = null;
			IceBlock.Item item = IceBlock.Item.NONE;
			Quaternion newQuaternion = new Quaternion (0, 0, 0, 1);
			if (num < 88) {
			} else if (num < 90) {
				child = fish;
				item = IceBlock.Item.FISH;
			} else if (num < 93) {
				child = fishBone;
				item = IceBlock.Item.FISH_BONE;
			} else if (num < 95) {
				child = heart;
				item = IceBlock.Item.HEART;
			} else if (num < 98) {
				child = skull;
				item = IceBlock.Item.SKULL;
				newQuaternion.y = -180;
			} else if (num < 100) {
				child = star;
				item = IceBlock.Item.STAR;
			}

			if (child != null) {
				Transform childClone = (Transform)Instantiate (child, position, newQuaternion);
				childClone.parent = iceBlockClone.GetComponent<Transform> ();
			}

			iceBlockClone.GetComponent<IceBlock> ().item = item;
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
		float zdelta = player.transform.position.z - player.GetComponent<PlayerMovement> ().prevPos.z;
		//print (zdelta);
		if (zpos - Mathf.Floor (zpos) < 0.15) {
			if (zdelta > 0.01) {
				SpawnBlock (zpos);
			}
		}
	}
}
