using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleSpawner : MonoBehaviour {

    public int radius;
    public int perfection;
    int numberOfPoints;
    public GameObject circlePointPrefab;


    void Awake()
    {
        numberOfPoints = perfection * 4;

        for (int i = 0; i < numberOfPoints; i++)
        {
            GameObject renamed = circlePointPrefab;
            renamed.name = "circle" + i;
//            circlePointPrefab.name = "circle" + i;
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(renamed, transform.position + pos, Quaternion.identity);
            
        }
    }
}
