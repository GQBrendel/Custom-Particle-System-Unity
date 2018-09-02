using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicFunctionParticleEmmiter : ParticleEmitter {
    public int numberOfPoints;
    [Range(0f, 5f)]
    public float lifeTime;

    int quebra;
    int faixa = 1;
    Vector3 segundaPos;
    int revertid = 0;

    void Start()
    {
        settings = GetComponent<ParticlesSettings>();
        StartCoroutine(spawnParticle());
    }
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
    public IEnumerator spawnParticle()
    {
        yield return new WaitForSeconds(spawnTimer);

        quebra = numberOfPoints / 2;
        revertid = numberOfPoints * 2;

        for (int i = 0; i < numberOfPoints; i++)
        {
            if (faixa == 1)
            {
                float angle = i * Mathf.PI * 2 / numberOfPoints;
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                Particle instance =
                Instantiate(selectedParticle, transform.position + pos, Quaternion.identity) as Particle;
                instance.transform.parent = transform;

                instance.GetComponent<Particle>().lifeTime = lifeTime;

                instance.GetComponent<Rigidbody>().velocity = pos * speed;
                particles.Add(instance);

                if (i == quebra)
                {
                    segundaPos = new Vector3((transform.position.x + 15), transform.position.y, transform.position.z);
                    faixa = 2;
                }
            }
            else if (faixa == 2)
            {               
                revertid--;
                float angle = i * Mathf.PI * 2 / numberOfPoints;
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                Particle instance =
                Instantiate(selectedParticle, segundaPos + pos, Quaternion.identity) as Particle;
                instance.transform.parent = transform;
                instance.GetComponent<Particle>().lifeTime = lifeTime;

                instance.GetComponent<Rigidbody>().velocity = pos * speed;
                particles.Add(instance);
                if(i == numberOfPoints-1)
                {
                    faixa = 1;
                }
            }
        }
        StartCoroutine(spawnParticle());

    }
}
