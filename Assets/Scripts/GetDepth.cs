using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDepth : MonoBehaviour
{
	public CharacterController controller;
	private float depth = 0f;
	private float velMag = 0f;
	private Vector3 vel;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(depth + ", " + velMag + ", " + vel);
    }
	
	void FixedUpdate() {
		Vector3 objectForward = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, objectForward, Color.green);
		Ray ray = new Ray(transform.position, objectForward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			// Debug.Log(hit.distance);
			depth = hit.distance;
		} else {
			depth = -1f;
		}
		
		Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
		vel = horizontalVelocity;
        velMag = horizontalVelocity.magnitude;
	}
}
