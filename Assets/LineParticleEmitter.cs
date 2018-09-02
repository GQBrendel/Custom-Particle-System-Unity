using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticlesSettings))]
public class LineParticleEmitter : MonoBehaviour {



    [Range(0f,2f)]
    public float spawnTimer;
    [Range(0f, 2f)]
    public float lifeTime;
    Particle selectedParticle;
    [HideInInspector]
    public List<Particle> particles;
    ParticlesSettings settings;

    

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
            else
            {
                particle.transform.position += Vector3.forward;
            }
        }
	}

    IEnumerator spawnParticle()
    {
        yield return new WaitForSeconds(spawnTimer);

        Particle instance = Instantiate(selectedParticle, transform.position, Quaternion.identity) as Particle;
        particles.Add(instance);
        instance.GetComponent<Particle>().lifeTime = lifeTime;
        StartCoroutine(spawnParticle());
    }
}
