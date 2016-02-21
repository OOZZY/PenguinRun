using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	void Update() {
		transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 5, 8)); 
	}
}