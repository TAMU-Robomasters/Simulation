using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float BlastPower = 5;

    public GameObject Cannonball;
    public Transform ShotPoint;
	
	bool autoFire = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			autoFire = true;
        }
		if (Input.GetMouseButtonUp(0)) {
			autoFire = false;
		}
		if (autoFire) {
			GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
		}
	}
}
