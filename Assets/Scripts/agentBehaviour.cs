using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class agentBehaviour : MonoBehaviour {

    public Transform destinationTarget;

    public Transform circle1, circle2, circle3, circle4;

    public float factor = 0f;
    int currentCirclePos;

    [Range(1.0f, 100f)]
    public float width = 5;
    [Range(1.0f, 100f)]
    public float height = 5;
    [Range(1.0f, 100f)]
    public float speed = 5;
    
    private Transform nextPoint;

    float timeCounter = 0;
    Vector3 startPos;

    void Start () {
        startPos = transform.position;
        currentCirclePos = 1;
       
        nextPoint = circle1;

      //  Instantiate(startPosPrefab, this.transform.position, Quaternion.identity);
    }
    void moveInCirclePath()
    {
        lookToPosition(nextPoint);
        transform.position = moveToPosition(transform.position, nextPoint.position, 0.5f);

        if (Vector3.Distance(transform.position, nextPoint.position) < 2f)
        {
            if (nextPoint == circle1)
            {
                nextPoint = circle2;
            }
            else if (nextPoint == circle2)
            {
                nextPoint = circle3;
            }
            else if (nextPoint == circle3)
            {
                nextPoint = circle4;
            }
            else if (nextPoint == circle4)
            {
                nextPoint = circle1;
            }
        }
    }

    void Update () {

        ///Move linear
        //transform.position = moveToPosition(transform.position, destinationTarget.position, 0.5f);

        //Move in circles
        //circleAroundPosition();

        // Move circle with defined path
        moveInCirclePath();
    }

    void circleAroundPosition()
    {


        lookToPosition(destinationTarget);

        timeCounter += Time.deltaTime * speed;

        float x = startPos.x + Mathf.Cos (timeCounter) * width;
        float y = startPos.y;
        float z = startPos.z + Mathf.Sin (timeCounter) * height;
        transform.position = new Vector3(x, y, z);
        

       // transform.rotation = new Quaternion(x, y + 90,
         //   z, transform.rotation.w);

        //lookToPosition(startPosPrefab);
        //270;
        


    }
    void lookToPosition(Transform destination)
    {
        /*
         Thanks Mike for help with the solution at: https://forum.unity.com/threads/implementing-a-manual-lookat.120308/
         */

            Vector3 viewForward = Vector3.zero;
            Vector3 viewUp = Vector3.zero;
            Vector3 viewRight = Vector3.zero;


            // Create viewVector
            viewForward = destination.position - transform.position;

            // normalize viewVector
            viewForward.Normalize();

        
            // Now we get the perpendicular projection of the viewForward vector onto the world up vector
            // Uperp = U - ( U.V / V.V ) * V
            viewUp = Vector3.up - (Vector3.Project(viewForward, Vector3.up));
            viewUp.Normalize();

            

            // Calculate rightVector using Cross Product of viewOut and viewUp
            // this is order is because we use left-handed coordinates
            viewRight = Vector3.Cross(viewUp, viewForward);


            // set new vectors
            transform.right = new Vector3(viewRight.x, viewRight.y, viewRight.z +factor);
            transform.up = new Vector3(viewUp.x, viewUp.y , viewUp.z + factor);
            transform.forward = new Vector3(viewForward.x, viewForward.y, viewForward.z + factor);
      
    }
    // Vector3.MoveTowards
    Vector3 moveToPosition(Vector3 currentPosition, Vector3 destination, float speed)
    {
        Vector3 positionsDifference = destination - currentPosition;

        float magnitude = positionsDifference.magnitude;
        if (magnitude <= speed || magnitude == 0f)
        {
            return destination;
        }
        return currentPosition + positionsDifference / magnitude * speed;
    }
}
