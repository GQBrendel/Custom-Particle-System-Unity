using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class agentBehaviour : MonoBehaviour {

    public Transform destinationTarget;
    
    public List<Transform> circlePoints;
    
    int currentCirclePos;
    
    [Range(0.0f, 10f)]
    public float speed = 0.2f;
    
    private Transform nextPoint;

    float timeCounter = 0;
    Vector3 startPos;

    void Start () {
        startPos = transform.position;
        currentCirclePos = 0;
       
        //nextPoint = circle1;

        foreach (GameObject point in GameObject.FindGameObjectsWithTag("circlePoint"))
        {
           // point.name = "circle" + currentCirclePos;
            circlePoints.Add(point.transform);
            currentCirclePos++;
        }
        //circlePoints = circlePoints.OrderBy(go => go.name).ToList();

        nextPoint = circlePoints[0];
        currentCirclePos = 0;


      //  Instantiate(startPosPrefab, this.transform.position, Quaternion.identity);
    }
    void moveInCirclePath()
    {
        lookToPosition(nextPoint);
        transform.position = moveToPosition(transform.position, nextPoint.position, speed);

        if (Vector3.Distance(transform.position, nextPoint.position) < 0.1f)
        {
            if(nextPoint == circlePoints[circlePoints.Count-1])
            {
                nextPoint = circlePoints[0];
                currentCirclePos = 0;
            }
            else if (nextPoint == circlePoints[currentCirclePos])
            {
                currentCirclePos++;
                nextPoint = circlePoints[currentCirclePos];
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
            transform.right = new Vector3(viewRight.x, viewRight.y, viewRight.z);
            transform.up = new Vector3(viewUp.x, viewUp.y , viewUp.z);
            transform.forward = new Vector3(viewForward.x, viewForward.y, viewForward.z);
      
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
