using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentBehaviour : MonoBehaviour {

    public Transform destinationTarget;

	// Use this for initialization
	void Start () {

        lookToPosition(destinationTarget);

    }
	
	// Update is called once per frame
	void Update () {

        transform.position = moveToPosition(transform.position, destinationTarget.position, 0.5f);
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

            // Alternatively for getting viewUp you could just use:
            // viewUp = thisTransform.TransformDirection(thisTransform.up);
            // viewUp.Normalize();


            // Calculate rightVector using Cross Product of viewOut and viewUp
            // this is order is because we use left-handed coordinates
            viewRight = Vector3.Cross(viewUp, viewForward);


            // set new vectors
            transform.right = new Vector3(viewRight.x, viewRight.y, viewRight.z);
            transform.up = new Vector3(viewUp.x, viewUp.y, viewUp.z);
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
