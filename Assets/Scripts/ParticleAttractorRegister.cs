using UnityEngine;
using System.Collections;

public class ParticleAttractorRegister : MonoBehaviour {
	
	public ParticleController particleController;
	
	// Use this for initialization
	void Start () {
		if (particleController == null) {
			throw new System.Exception("You have to set the reference to a ParticleController.");
		}
		particleController.addAttractor(transform);
	}
	
	void Destroy() {
		particleController.removeAttractor(transform);
	}
}
