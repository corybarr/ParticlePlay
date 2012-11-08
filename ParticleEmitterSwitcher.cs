using UnityEngine;
using System.Collections;

public class ParticleEmitterSwitcher : MonoBehaviour {
	
	public ParticleEmitter[] particleEmitters;
	public float secsBetweenSwitches = 45.0f;
	
	private int numEmitters;
	private float secsUntilSwitch;
	private int currentOnEmitterIndex = 0;
	
	// Use this for initialization
	void Start () {
		numEmitters = particleEmitters.GetLength(0);
		secsUntilSwitch = secsBetweenSwitches;
		
		foreach (ParticleEmitter particleEmitter in particleEmitters) {
			particleEmitter.emit = false;
		}
		
		particleEmitters[currentOnEmitterIndex].emit = true;
	}
	
	// Update is called once per frame
	void Update () {
		secsUntilSwitch -= Time.deltaTime;
		
		if (secsUntilSwitch < 0) {
			particleEmitters[currentOnEmitterIndex].emit = false;
			currentOnEmitterIndex++;
			currentOnEmitterIndex %= numEmitters;
			particleEmitters[currentOnEmitterIndex].emit = true;
			
			secsUntilSwitch = secsBetweenSwitches;
		}
	}
}
