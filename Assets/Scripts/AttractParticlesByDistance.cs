using UnityEngine;
using System.Collections;

public class AttractParticlesByDistance : MonoBehaviour {
	
	public ParticleEmitter pe;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pe.worldVelocity = transform.position;
	}
	
	void OnMouseDown() {
		Debug.Log("Mouse button pressed");
		
	}
}
