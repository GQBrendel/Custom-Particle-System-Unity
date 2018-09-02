using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineSpawner : MonoBehaviour {

    public int howFar;
    int numberOfPoints;
    public GameObject circlePointPrefab;


    void Awake()
    {
        circlePointPrefab.name = "track0";        
        Vector3 pos = new Vector3(transform.position.x + howFar, transform.position.y, transform.position.z);
        GameObject instance =
        Instantiate(circlePointPrefab, transform.position + pos, Quaternion.identity) as GameObject;
        instance.transform.parent = transform;
        instance.GetComponent<idKeeper>().id = 0;

        circlePointPrefab.name = "track1";
       // pos = new Vector3(transform.position.x + howFar, transform.position.y, transform.position.z);
        instance =
        Instantiate(circlePointPrefab, transform.position, Quaternion.identity) as GameObject;
        instance.transform.parent = transform;
        instance.GetComponent<idKeeper>().id = 1;
    }
}
