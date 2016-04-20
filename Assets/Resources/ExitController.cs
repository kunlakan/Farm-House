//------------------------------------------------------------------------------
//  ExitController.cs
//  Created and modified by Kunlakan Cherdchusilp and Vuochly Ky (Nin)
//	Created on March 15th, 2016
//------------------------------------------------------------------------------
// ExitController that is check if the user ever press the "ESC" key on the
// keyboard. If the user ever press the "ESC" key, the program will paused and 
// and a menu display. The menu has two buttons, 'Continue' and 'Exit'.
//------------------------------------------------------------------------------


using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject controller;

	// keepGoing method is called when the 'Continue' button is clicked.
	public void keepGoing(){
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
		controller.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
	}

	// exit method is existed to exit the program when the user clicked on the 
	// 'Exit' button
	public void exit(){
		Application.Quit ();
	}


	// Checks every frame if the user ever pressed the "ESC" key. If so,
	// the game is paused, and a menu display. The menu has two buttons, 
	// 'Continue' and 'Exit'
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
			controller.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = false;
			
		}
	}
}
