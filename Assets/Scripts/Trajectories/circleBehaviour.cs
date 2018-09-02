using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleBehaviour : MonoBehaviour {

    Vector3 startPos;
    [Range(1.0f, 100f)]
    public float raio = 5;
    [Range(1.0f, 100f)]
    public float speed = 5;
    float timeCounter = 0;
    // Use this for initialization
    void Start () {

        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        circleAroundPosition();

    }
    void circleAroundPosition()
    {
        

        timeCounter += Time.deltaTime * speed;

        float x = startPos.x + Mathf.Cos(timeCounter) * raio;
        float y = startPos.y;
        float z = startPos.z + Mathf.Sin(timeCounter) * raio;
        transform.position = new Vector3(x, y, z);

        //lookToPosition(startPosPrefab);
        //270;



    }
}
