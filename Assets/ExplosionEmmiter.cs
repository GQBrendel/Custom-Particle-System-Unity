using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEmmiter : CircleParticleEmmiter {

    public Particle explosionSphereParticle, explosionCubeParticle, explosionCylinderParticle;

    void Start () {

        settings = GetComponent<ParticlesSettings>();
        settings.sphereParticle = explosionSphereParticle;
        settings.cubeParticle = explosionCubeParticle;
        settings.cylinderParticle = explosionCylinderParticle;
        StartCoroutine(spawnParticle());
	}
	
	// Update is called once per frame
	void Update () {
        selectedParticle = settings.getSelectedParticle();
        if (particles.Count > 0 && particles[0].shouldDie())
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                particles[i].destroyParticle();
            }
            particles.RemoveRange(0, numberOfPoints);
        }
    }
}
