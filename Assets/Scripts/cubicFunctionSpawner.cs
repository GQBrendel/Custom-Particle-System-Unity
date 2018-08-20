using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubicFunctionSpawner : MonoBehaviour {

    public int radius;
    public int numberOfPoints;
    public GameObject circlePointPrefab;
    int quebra;
    int faixa = 1;
    Vector3 segundaPos;
    int revertid = 0;


    void Awake()
    {
        quebra = numberOfPoints / 2;
        revertid = numberOfPoints * 2;


        for (int i = 0; i < numberOfPoints; i++)
        {
            if (faixa == 1)
            {
                circlePointPrefab.name = "circle" + i;
                float angle = i * Mathf.PI * 2 / numberOfPoints;
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                GameObject instance =
                Instantiate(circlePointPrefab, transform.position + pos, Quaternion.identity) as GameObject;
                instance.transform.parent = transform;

                instance.GetComponent<idKeeper>().id = i;
                if (i == quebra)
                {
                    segundaPos = new Vector3(transform.position.x + (radius*2), transform.position.y, transform.position.z);
                    faixa = 2;
                }
            }
            else if (faixa ==2)
            {
                circlePointPrefab.name = "circle" + revertid;
                revertid--;
                float angle = i * Mathf.PI * 2 / numberOfPoints;
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                GameObject instance =
                Instantiate(circlePointPrefab, segundaPos + pos, Quaternion.identity) as GameObject;
                instance.transform.parent = transform;

                instance.GetComponent<idKeeper>().id = revertid;

            }
        }
    }
}
