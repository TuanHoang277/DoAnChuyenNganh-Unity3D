﻿using UnityEngine;
using System.Collections;

public class GameController_Friction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnMainScene() 
	{
		Application.LoadLevel ("DACN_Main");
		//GameManager.Instance.LoadSceneDACN ();
	}
}
