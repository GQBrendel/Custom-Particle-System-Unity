using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticlesSettings))]
public class LineParticleEmitter : ParticleEmitter {

    [Range(0f, 5f)]
    public float lifeTime;

    void Start () {
        settings = GetComponent<ParticlesSettings>();
        StartCoroutine(spawnParticle());
    }

    void Update () {
        selectedParticle = settings.getSelectedParticle();
        foreach (Particle particle in particles)
        {
            if(particle.shouldDie())
            {
                particles.Remove(particle);
                Destroy(particle.gameObject);
            }
        }
	}

    IEnumerator spawnParticle()
    {
        yield return new WaitForSeconds(spawnTimer);

        Particle instance = Instantiate(selectedParticle, transform.position, Quaternion.identity) as Particle;
        particles.Add(instance);
        instance.GetComponent<Particle>().lifeTime = lifeTime;

        instance.GetComponent<Rigidbody>().velocity = gameObject.transform.TransformDirection(new Vector3(-1, 0, 0) * speed);
        StartCoroutine(spawnParticle());
    }
}
