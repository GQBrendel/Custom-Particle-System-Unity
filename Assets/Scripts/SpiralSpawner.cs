using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralSpawner : MonoBehaviour {

    public int radius;
    public int perfection;
    int numberOfPoints;
    public GameObject circlePointPrefab;
    public float offset;


    void Awake()
    {
        numberOfPoints = perfection * 4;

        for (int i = 0; i < numberOfPoints; i++)
        {

            circlePointPrefab.name = "circle" + i;
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * angle * radius;

            GameObject instance =
            Instantiate(circlePointPrefab, transform.position + pos, Quaternion.identity) as GameObject;
            instance.transform.parent = transform;
            
        }
        
    }
}
