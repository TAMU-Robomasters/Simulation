using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDepth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate() {
		Vector3 objectForward = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, objectForward, Color.green);
		Ray ray = new Ray(transform.position, objectForward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			Debug.Log(hit.distance);
		}
	}
}
