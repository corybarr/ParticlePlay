using UnityEngine;
using System.Collections;

public class ParticleAttracterRegisterOnPointCloudCollision : MonoBehaviour {

	public PointCloudFadingCollider pointCloudFadingCollider;
	public ParticleController particleController;
	
	void OnPointCloudCollisionEnter() {
		particleController.addAttractor(transform);
	}
	
	void OnPointCloudCollisionExit() {
		particleController.removeAttractor(transform);
	}
}
