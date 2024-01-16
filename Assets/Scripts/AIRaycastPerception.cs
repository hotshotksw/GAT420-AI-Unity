using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIRaycastPerception : AIPerception
{
	[SerializeField][Range(2, 50)] int numRaycast = 2;
	
	public override GameObject[] GetGameObjects()
	{
		List<GameObject> result = new List<GameObject>();

		Vector3[] directions = Utilities.GetDirectionsInCircle(numRaycast, maxAngle);
		foreach (Vector3 direction in directions)
		{
			Ray ray = new Ray(transform.position, transform.rotation * direction);
			Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
			if (Physics.Raycast(ray, out RaycastHit raycastHit, distance))
			{
				// check if collision is self, skip if so
				if (raycastHit.collider.gameObject == gameObject) continue;
				if (tagName == "" || raycastHit.collider.CompareTag(tagName))
				{
					result.Add(raycastHit.collider.gameObject);
				}
			}
		}

		// remove duplicates
		result = result.Distinct().ToList();

		return result.ToArray();
	}
}
