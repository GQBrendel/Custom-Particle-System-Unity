﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour {


    [Range(0f, 3f)]
    public float spawnTimer;  
    [Range(0f, 20f)]
    public float speed;
    [HideInInspector]
    public Particle selectedParticle;
    [HideInInspector]
    public List<Particle> particles;
    [HideInInspector]
    public ParticlesSettings settings;
}
