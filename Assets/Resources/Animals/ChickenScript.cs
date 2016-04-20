/*
    Created by:  Sandy Chau
    Date:        March 15, 2016
    Description: This will animate the animal by switching the modes to animate. It also finds a new 
                 location to move the animal to it. 
    Sources: https://www.youtube.com/watch?v=z6h3aE9LIxk
             http://answers.unity3d.com/questions/969835/i-need-help-making-a-free-roaming-script-for-anima.html
*/
using UnityEngine;
using System.Collections;

public class ChickenScript : MonoBehaviour {
    private Animator animal;
    public float speed = 2f;//Speed of the animal

    public Vector3 targetPosition;
    public float waitTime = 3f;//wait time between each walk 
    public bool isMoving = false;
    public float maxRange = 10f;

    //The boundries for the animals to roam
    private int maxX = 170;
    private int minX = 70;
    private int maxZ = 388;
    private int minZ = 332;


    // Used for initialization
    void Start()
    {
        animal = gameObject.GetComponentInChildren<Animator>();

        animal.SetInteger("Aniparam", 1);//Set of default stance of animal
    }

    // Update is called once per frame
    void Update()
    {
        //If animal is not moving, find a position to move towards it
        if (isMoving == false)
        {
            FindTargetPosition();
        }
    }

    /*
        Random number generator to find new location of the animal
        Code modified from: http://answers.unity3d.com/questions/969835/i-need-help-making-a-free-roaming-script-for-anima.html
    */
    private void FindTargetPosition()
    {
        Vector3 currentPosition = transform.position;
        targetPosition = new Vector3();

        //Find a new position that is within the boundries set
        targetPosition.x = Random.Range(minX, maxX);
        targetPosition.y = currentPosition.y;
        targetPosition.z = Random.Range(minZ, maxZ);

        StartCoroutine(Move());
    }

    /*
        Moves the animal in cycles 
        Code modified from http://answers.unity3d.com/questions/969835/i-need-help-making-a-free-roaming-script-for-anima.html
    */
    IEnumerator Move()
    {
        //If the animal is moving, switch the animation stance
        isMoving = true;
        if (isMoving == true)
        {
            animal.SetInteger("Aniparam", 1);
        }

        //Rotate animal to look towards the new location
        transform.LookAt(targetPosition);
        transform.Rotate(0, 90f, 0);// Turns the animal to face towards the 

        //Slowly move the animal towards the new location
        while (transform.position != targetPosition)
        {
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime / 2);
                yield return null;
            }

            //When it reaches the location, stop the walking animation
            if (transform.position == targetPosition)
            {
                isMoving = false;
                animal.SetInteger("Aniparam", 0);
            }
        }

        //Wait before walking again
        yield return new WaitForSeconds(waitTime);
        yield return null;
    }
}
