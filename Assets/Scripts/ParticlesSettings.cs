using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSettings : MonoBehaviour {

    public enum form
    {
        Cube,
        Sphere,
        Cylinder
    }
    public form particleShape;
    [Range(0f, 30f)]
    public float scale;
    public Particle sphereParticle, cubeParticle, cylinderParticle;
    public Material particleMaterial;
    public Color particleColor;
    Particle selectedParticle;
    Vector3 scaleFactor;

    void Start () {
        getSelectedParticle();

    }
  
	// Update is called once per frame
	void Update () {
        particleMaterial.color = particleColor;
        scaleFactor = new Vector3(scale, scale, scale);
        selectedParticle.transform.localScale = scaleFactor;
	}
    public Particle getSelectedParticle()
    {
        if (particleShape == form.Cube)
        {
            selectedParticle = cubeParticle;
        }
        else if (particleShape == form.Sphere)
        {
            selectedParticle = sphereParticle;
        }
        else if (particleShape == form.Cylinder)
        {
            selectedParticle = cylinderParticle;
        }
        return selectedParticle;
    }

}
