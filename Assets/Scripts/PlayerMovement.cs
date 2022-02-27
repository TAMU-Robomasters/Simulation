using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	
	public float speed = 12;
	
	Vector3 position;
	

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x + transform.forward * z;
		move = move.normalized;
		
		controller.Move(move * speed * Time.deltaTime);
		
		transform.position.Set(transform.position.x, 0.5f, transform.position.z);
    }
}
