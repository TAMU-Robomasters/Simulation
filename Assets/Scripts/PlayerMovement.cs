using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	public BoxCollider boxCollider;

	public float speed = 12;
	
	Vector3 position;
	
	void Start()
    {
		this.controller.radius = 0;
		this.controller.center = new Vector3(0, 0, 0);
    }

	/**
	 * Called once per frame
	 */
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x + transform.forward * z;
		move = move.normalized;
		
		this.controller.Move(move * speed * Time.deltaTime);
		this.transform.position.Set(transform.position.x, 0.1f, transform.position.z);
    }
}
