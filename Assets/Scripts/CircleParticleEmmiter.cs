using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticlesSettings))]
public class CircleParticleEmmiter : ParticleEmitter {

    public int numberOfPoints;
    [Range(0f, 5f)]
    public float lifeTime;

    void Start () {

        settings = GetComponent<ParticlesSettings>();
        StartCoroutine(spawnParticle());

    }
	
	void Update () {

        selectedParticle = settings.getSelectedParticle();
        if(particles.Count > 0 && particles[0].shouldDie())
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                particles[i].destroyParticle();
            }
            particles.RemoveRange(0, numberOfPoints);
        }
    }
    public IEnumerator spawnParticle()
    {
        yield return new WaitForSeconds(spawnTimer);

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));// * radius;
            Particle instance =
            Instantiate(selectedParticle, transform.position + pos, Quaternion.identity) as Particle;
            //instance.transform.parent = transform;

            

            instance.GetComponent<Particle>().lifeTime = lifeTime;

            instance.GetComponent<Rigidbody>().velocity = pos * speed;
            particles.Add(instance);
        }
        StartCoroutine(spawnParticle());

    }
}
