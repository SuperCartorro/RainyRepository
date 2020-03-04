using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			Application.LoadLevel(Application.loadedLevel +1);
		}
	}
}