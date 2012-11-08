using UnityEngine;
using System.Collections;

public class ParticleEmitterRegister : MonoBehaviour {
	
	public ParticleController particleController;
	private ParticleEmitter pe;
	
	// Use this for initialization
	void Start () {
		pe = transform.GetComponent<ParticleEmitter>();
		if (pe == null) {
			throw new System.Exception("The gameobject must have a ParticleEmitter for this script to work.");
		}
		particleController.addEmitter(pe);
	}
	
	void Destroy() {
		particleController.removeEmitter(pe);
	}
}
