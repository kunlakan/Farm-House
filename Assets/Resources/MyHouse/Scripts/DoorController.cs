//------------------------------------------------------------------------------
//  DoorController.cs
//  Created by Kunlakan Cherdchusilp
//	Created on March 10th, 2016
//------------------------------------------------------------------------------
// DoorController checks if the user click on the gameObject, which is designed
// to be a door, for the first time, the gameObject will play the open animation.
// The the gameObject is clicked again, the gameObject will play the close
// animation.
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public AnimationClip open;
	public AnimationClip close;

	private bool isOpen = false;

	/* Checks if the user click on the gameObject. If so:
	*	- If the door is opened, close it
	*	- If the door is closed, open it
	*/
	void OnMouseDown(){
		// If the door is closed, open it
		if (!isOpen) {
			GetComponent<Animation> ().Play (open.name);
			isOpen = true;
		}

		// f the door is opened, close it
		else {
			GetComponent<Animation> ().Play (close.name);
			isOpen = false;
		}
	}
}
