using UnityEngine;
using System.Collections;

public class Levelchange1 : MonoBehaviour {
	
	// Use this for initialization
	void Update() {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel(Application.loadedLevel +1);
		}
	}
}