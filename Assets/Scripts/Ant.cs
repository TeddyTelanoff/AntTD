using System;

using UnityEngine;
using PathCreation;

public class Ant: MonoBehaviour
{
	public PathCreator pathCreator;
	public float speed;
	float distTravelled;

	void FixedUpdate() {
		distTravelled += speed * Time.deltaTime;
		transform.position = pathCreator.path.GetPointAtDistance(distTravelled, EndOfPathInstruction.Stop);
		Vector3 rotEuler = pathCreator.path.GetRotationAtDistance(distTravelled, EndOfPathInstruction.Stop).eulerAngles;
		transform.rotation = Quaternion.Euler(rotEuler.x + 90, rotEuler.y, rotEuler.z - 90);
		
		if (distTravelled >= pathCreator.path.length)
			Destroy(gameObject);
	}
}
