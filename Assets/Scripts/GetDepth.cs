using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public class GetDepth : MonoBehaviour
{
	/**
	 * String for file type
	 */
	protected const string file_type = ".csv";


	protected UTF8Encoding utf8 = new UTF8Encoding(true);

	protected string path;

	// CharacterController
	public CharacterController controller;

	/**
	 * The magnitude of the depth vector.
	 * The direction of the vector is the same as the camera.
	 * The vector goes from the camera to any collidable object.
	 */
	private float depth = 0f;

	/**
	 * Magnitude of the velocity vector.
	 * See vel
	 */
	private float velMag = 0f;

	/**
	 * The Velocity Vector
	 */
	private Vector3 vel;

	private StreamWriter GlobalWriter;
	
    // Start is called before the first frame update
    void Start()
    {
		path = Directory.GetCurrentDirectory() + "\\SimRun-" + DateTime.Now.ToString("yyyy-MM-ss-HH-mm-ss") + file_type;
		Debug.Log(path);
		using (FileStream fs = File.Create(path))
        {
			byte[] info = utf8.GetBytes("Depth,Speed,Velocity (x),Velocity (y),Velocity (z)\n");
			fs.Write(info, 0, info.Length);
		}
    }

    // Update is called once per frame
    void Update()
    {
		string data = depth + "," + velMag + "," + vel.x + "," + vel.y + "," + vel.z;
		Debug.Log(data);
		using (GlobalWriter = File.AppendText(path))
        {
			GlobalWriter.WriteLine(data);
        }
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
