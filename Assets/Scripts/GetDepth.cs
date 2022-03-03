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
	 * TODO:
	 *	Remove velocity
	 *	Retrieve position and rotation.
	 *	Record each run of the simulation.
	 *	Add time data.
	 *	
	 */

	// CharacterController
	public CharacterController controller;
	
	/**
	 * String for file type
	 */
	protected const string file_type = ".csv";
	
	/**
	 * UTF8Encoding
	 */
	protected UTF8Encoding utf8 = new UTF8Encoding(true);

	/**
	 * Current directory of this project.
	 */
	protected string path;

	/**
	 * Start time of the current simulation run.
	 */
	protected DateTime StartTime;

	/**
	 * StreamWriter to write to csv file.
	 */
	protected StreamWriter GlobalWriter;

	/**
	 * Difference between DateTime.Now and StartTime
	 */
	protected double time;

	/**
	 * The magnitude of the depth vector.
	 * The direction of the vector is the same as the camera.
	 * The vector goes from the camera to any collidable object.
	 */
	protected float depth = 0f;

	/**
	 * Magnitude of the velocity vector.
	 * See vel
	 */
	protected float velMag = 0f;

	/**
	 * The Velocity Vector
	 */
	protected Vector3 vel;
	
	/**
	 * The Position Vector
	 */
	protected Vector3 pos;

	/**
	 * The Rotation Vector
	 */
	protected Vector3 rot;

	/**
     * Start is called before the first frame update
     */
	void Start()
    {
		StartTime = DateTime.Now;
		path = Directory.GetCurrentDirectory() + @"\SimRun-" + StartTime.ToString("yyyy-MM-dd-HH-mm-ss") + file_type;
		Debug.Log(path);
		using (FileStream fs = File.Create(path))
        {
			byte[] info = utf8.GetBytes("Time,Depth,Position (x),Position (y),Position (z),Rotation (x), Rotation (y),Rotation (z),Velocity (x),Velocity (y),Velocity (z)\n");
			fs.Write(info, 0, info.Length);
		}
    }

	/**
     * This method is called once per Render Frame.
     */
	void Update()
    {
		string data = time + "," + depth + "," + pos.x + "," + pos.y + "," + pos.z + "," + rot.x + "," + rot.y + "," + rot.z + "," + vel.x + "," + vel.y + "," + vel.z;
		// Debug.Log(data);
		using (GlobalWriter = File.AppendText(path))
        {
			GlobalWriter.WriteLine(data);
        }
	}
	
	/**
	 * This method is called once per Physics Frame
	 */
	void FixedUpdate() {
		Vector3 objectForward = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, objectForward, Color.green);
		Ray ray = new Ray(transform.position, objectForward);
		RaycastHit hit;

		Vector3 horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);

		time = (DateTime.Now - StartTime).TotalSeconds;
		depth = Physics.Raycast(ray, out hit) ? hit.distance : -1f;
		pos = transform.position;
		rot = transform.rotation.eulerAngles;
		vel = horizontalVelocity;
        velMag = horizontalVelocity.magnitude;
	}
}
