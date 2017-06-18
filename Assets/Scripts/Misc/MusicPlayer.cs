using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

	//only 1 music player for this game (singleton)
	static MusicPlayer player = null;

	void Awake ()
	{
		//singleton logic
		if (player == null) {

			//player is the global MusicPlayer (this) --> now not null
			player = this;

			//gameObject - the Music Player object
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
