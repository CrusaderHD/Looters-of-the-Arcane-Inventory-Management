using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script get attached to the GameManager. Controls camera transfer from PLayer to RC Car and Back.
public class Remote : MonoBehaviour {

	public GameManager gameMan;
	public GameObject playerCamera;
	public Camera rcCamera;
	public UserInterface hud;

	// Use this for initialization
	void Start () {
		gameMan = gameObject.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C))
		{
			if(gameMan.driving)
			{
				gameMan.driving = false;
				playerCamera.SetActive(true);
				rcCamera.gameObject.SetActive(false);
				hud.crosshair.SetActive(true);
			}
			else
			{
				gameMan.driving = true;
				playerCamera.SetActive(false);
				rcCamera.gameObject.SetActive(true);
				hud.crosshair.SetActive(false);
			}
		}
	}
}
