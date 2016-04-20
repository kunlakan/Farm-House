/*
 * Modified by Vuochly Ky and Kunlakan Cherdchusilp
 * Date: March 15, 2016
 * 
 * Descrption: This makes a day and night cycle in the world. Code was
 * 			   from the website: http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5
 * 			   Code is mainly from the website, Vuochly only removed unused some code and changed some 
 * 			   variable values.
 * 
 */
using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {

	public Light sunlight;
	public float secondsInFullDay = 200f; // one day cycle
	public float currentTimeOfDay = 0;
	public float speed = 1f;

	private float lightInitlIntensity;
	private float pausedSpeed = 0f;
	private bool isPause = false;


	/*
	 * Initialize the lightInitensity on start
	 */
	void Start() {
		lightInitlIntensity = sunlight.intensity;
	}

	/*
	 * Moves the sun on every frame
	 * Code from: http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5
	 * 
	*/
	void Update() {
		UpdateSunLight();

		currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * speed;

		if (currentTimeOfDay >= 1) {
			currentTimeOfDay = 0;
		}
	}

	/*
	 * Method will update the light source in the world
	 * Code from: http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5
	 */

	void UpdateSunLight() {
		sunlight.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

		float intensityMultiplier = 1;
		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
			intensityMultiplier = 0;
		}
		else if (currentTimeOfDay <= 0.25f) {
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
		}
		else if (currentTimeOfDay >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
		}

		sunlight.intensity = lightInitlIntensity * intensityMultiplier;
	}

	/*
	 * This method will change the speed of the day and night cycle according to
	 * the slider on the game's scene
	 */
	public void changeSpeed(float value){
		if (value == 1)
			speed = value;
		else
			speed = value * value;
		isPause = false;

	}

	/*
	 * This method will pause and unpause the day and night cyle feature
	 */
	public void puaseTime(){
		if (isPause) {
			isPause = false;
			speed = pausedSpeed;
		} else {
			isPause = true;
			pausedSpeed = speed;
			speed = 0f;
		}
	}
}
