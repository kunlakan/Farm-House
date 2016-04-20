//------------------------------------------------------------------------------
//  WaterController.cs
//  Created by Kunlakan Cherdchusilp
//	Created on March 10th, 2016
//------------------------------------------------------------------------------
// WaterController checks if the user click on the gameObject, which is designed
// to be water taps. The WaterContoller will communicate with another
// gameObject so that:
//	- When one water taps is on, the water should come out of the water tap
//	- When only one of the water tap is on, the water should also come out of
//	  the water tap.
//	- When both of the water tap is off, then the water should stop.
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {

	public AnimationClip open;
	public AnimationClip close;

	public GameObject water;
	public GameObject OtherTap = null;

	private bool isOpen = false;
	private bool isOtherOpen = false;

	/* Checks if the user click on the gameObject. If so:
	*	- When one water taps is on, the water should come out of the water tap
	*	- When only one of the water tap is on, the water should also come out of
	*	  the water tap.
	*	- When both of the water tap is off, then the water should stop.
	*/
	void OnMouseDown(){
		
		// If both taps are not on, turn on this water tap and plays the
		// open animation
		if (!isOpen && !isOtherOpen) {
			GetComponent<Animation> ().Play (open.name);
			water.SetActive (true);
			water.GetComponent<ParticleSystem> ().Play ();
			isOpen = true;

			if (OtherTap != null)
				OtherTap.GetComponent<WaterController> ().setOtherOpen (isOpen);
		}

		// If this water tap is not on but the other does, only plays the
		// open animation
		else if (!isOpen && isOtherOpen) {
			GetComponent<Animation> ().Play (open.name);
			isOpen = true;

			if (OtherTap != null)
				OtherTap.GetComponent<WaterController> ().setOtherOpen (isOpen);
		}

		// If both of the water taps are on, only plays the close animation
		else if (isOpen && isOtherOpen) {
			GetComponent<Animation> ().Play (close.name);
			isOpen = false;

			if (OtherTap != null)
				OtherTap.GetComponent<WaterController> ().setOtherOpen (isOpen);
		}
			
		// If this water tap is not on but the other does not, turn off this water
		// tap and plays the close animation
		else if (isOpen && !isOtherOpen){
			GetComponent<Animation> ().Play (close.name);
			water.GetComponent<ParticleSystem> ().Stop ();
			water.SetActive (false);
			isOpen = false;

			if (OtherTap != null)
				OtherTap.GetComponent<WaterController> ().setOtherOpen (isOpen);
		}
	}

	/* Send message to OtherTap water tap, so it knows the status of this water tap.
	 */
	public void setOtherOpen(bool status){
		isOtherOpen = status;
	}
}
