using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    public float lifeTime;
    [HideInInspector]
    public bool dieTime;
    float livedTime; 
    
    void Start () {
        livedTime = 0;		
	}

    public bool shouldDie()
    {
        return livedTime >= lifeTime;
    }
    public void destroyParticle()
    {
        Destroy(gameObject);
    }

	void Update () {

        livedTime += Time.deltaTime;
	}
}
