using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticlesSettings))]
public class CircleParticleEmmiter : ParticleEmitter {

    public int numberOfPoints;

    public float radius;
   // int n = 0;
    // Use this for initialization
    void Start () {

        settings = GetComponent<ParticlesSettings>();
        StartCoroutine(spawnParticle());

    }
	
	// Update is called once per frame
	void Update () {

        selectedParticle = settings.getSelectedParticle();
        
        foreach (Particle particle in particles)
        {
           // float angle = /*n **/ Mathf.PI * 2 / numberOfPoints;
           // Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (radius/*+n*/);
           // particle.transform.position = pos;
            if (particle.shouldDie())
            {
                particles.Remove(particle);
                Destroy(particle.gameObject);
            }
//            n++;
        }

    }
    IEnumerator spawnParticle()
    {
        yield return new WaitForSeconds(spawnTimer);

        for (int i = 0; i < numberOfPoints; i++)
        {
            selectedParticle.gameObject.name = "circle" + i;

            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Particle instance =
            Instantiate(selectedParticle, transform.position + pos, Quaternion.identity) as Particle;
            instance.transform.parent = transform;

            particles.Add(instance);

            instance.lifeTime = lifeTime;

            instance.GetComponent<Rigidbody>().velocity = pos * speed;
        }
        StartCoroutine(spawnParticle());

    }
}
