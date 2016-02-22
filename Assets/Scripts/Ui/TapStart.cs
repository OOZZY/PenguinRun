using UnityEngine;
using System.Collections;

public class TapStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Level01");
		}
	}
}
