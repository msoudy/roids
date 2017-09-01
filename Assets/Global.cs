using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public GameObject objToSpawn;
	public float timer;
	public float spawnPeriod;
	public int numberSpawnedEachPeriod;
	public Vector3 originInScreenCoords;
	public int score;
	// Use this for initialization
	void Start () {
		score = 0;
		timer = 0;
		spawnPeriod = 5.0f;
		numberSpawnedEachPeriod = 3;
		/*
            So here's a design point to consider:
			- is the gameplay constrained by the screen size in any particular way?
			That might sound like a weird question, but it's actually a significant one for asteroids if you want the game to play like Asteroids on arbitrary screen dimensions. It's mostly here for pedagogical reasons, though. The value that actually matters here is the depth value. Since the gameplay takes place on a XZ- plane, and we're looking down the Y-axis,
			we're mainly interested in what the Y value of 0 maps to in the camera's depth.
		*/
		originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0,0,0));
	}


	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if( timer > spawnPeriod )
		{
			timer = 0;
			float width = Screen.width;
			float height = Screen.height;
			for( int i = 0; i < numberSpawnedEachPeriod; i++ )
			{
				float horizontalPos = Random.Range(0.0f, width); float verticalPos = Random.Range(0.0f, height);
				Instantiate(objToSpawn,
					Camera.main.ScreenToWorldPoint(
						new Vector3(horizontalPos, verticalPos,originInScreenCoords.z)), Quaternion.identity );
			}
		}
	}


}
