using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float Power = 5;
	public float fireRate = 0.15f;

    public GameObject Bullet;
    public Transform ShotPoint;
	
	bool autoFire = false;
	bool allowFire = false;
	
	IEnumerator FireRate()
    {
		allowFire = false;
		GameObject CreatedBullet = Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
        CreatedBullet.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * Power;
		yield return new WaitForSeconds(fireRate);
		allowFire = true;
    }
	
	void Start() {
		allowFire = true;
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			autoFire = true;
        }
		if (Input.GetMouseButtonUp(0)) {
			autoFire = false;
		}
		if (autoFire && allowFire) {
			StartCoroutine(FireRate());
		}
	}
}
