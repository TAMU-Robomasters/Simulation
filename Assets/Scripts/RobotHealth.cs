using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
	public float healthEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "mainBullet") {
			healthEnemy -= 10f;
			Debug.Log(healthEnemy);
		}
	}
}
