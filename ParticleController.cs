using UnityEngine;
using System.Collections.Generic;

public class ParticleController : MonoBehaviour {

	public float ignoreAttractorIfCloserThan = 4.0f;
	
	private HashSet<Transform> particleAttractors = new HashSet<Transform>();
	private HashSet<ParticleEmitter> particleEmitters = new HashSet<ParticleEmitter>();
	
	void Update () {
		foreach (ParticleEmitter p in particleEmitters) {
			Particle[] particles = p.particles;
			for (int i=0; i < particles.GetLength(0); i++) {
				particles[i].velocity = 
					calcWeightedParticleVector(particles[i], particleAttractors);
			}
			p.particles = particles;
		}
	}
	
	public bool addAttractor(Transform t) {
		//particleAttractors.Add(t.GetHashCode().ToString(), t);
		particleAttractors.Add(t);
		return true;
	}
	
	public bool removeAttractor(Transform t) {
		particleAttractors.Remove(t);
		return true;
	}
	
	public bool addEmitter(ParticleEmitter p) {
		particleEmitters.Add(p);
		return true;
	}
	
	public bool removeEmitter(ParticleEmitter p) {
		particleEmitters.Remove(p);
		return true;
	}

	Vector3 calcWeightedParticleVector(Particle particle, HashSet<Transform> attractors) {
		
		Vector3 totalAttractorsVector = Vector3.zero;
		
		foreach (Transform t in attractors) {
			float distanceToAttractor = 
				Mathf.Max(Vector3.Distance(particle.position, t.position), ignoreAttractorIfCloserThan);
			float inverseDistToAttractor = 1 / Mathf.Pow(distanceToAttractor, 2.0f);
			totalAttractorsVector += 
				inverseDistToAttractor * Vector3.Normalize(t.position - particle.position);
		}
		
		float origParticleMag = particle.velocity.magnitude;
		Vector3 newVelocity = particle.velocity + totalAttractorsVector;
		return Vector3.Normalize(newVelocity) * origParticleMag;
	}
}

