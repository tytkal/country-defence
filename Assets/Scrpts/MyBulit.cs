﻿using UnityEngine;
using System.Collections;

public class MyBulit : MonoBehaviour {
	public float speed = 20f;
	public Rigidbody2D rigi;
	private Camera camera;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").camera;
		GameObject gameControllerObject = GameObject.Find("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && !gameController.isGameOver()) {
			Rigidbody2D bulletInstance;
			Vector3 pz = camera.ScreenToWorldPoint(Input.mousePosition );
			if(pz.y < 0.7)
			{
				gameController.decreaseText();
				bulletInstance = Instantiate(rigi, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				 bulletInstance.velocity = new Vector2(speed, pz.y*2);
			}

		
		}
	}
}
