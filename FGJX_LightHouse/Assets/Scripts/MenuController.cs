﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public void PLAY(){
		SceneManager.LoadScene("Game");
	}

	public void EXIT(){
		Application.Quit ();
	}




}