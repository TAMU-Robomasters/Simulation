using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
	EnemyControl enemyControl = null;
	
    // Start is called before the first frame update
    void Start()
    {
        enemyControl = GameObject.Find("StandardEnemy").GetComponent<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "mainBullet") {
			if (gameObject.tag == "plate0") {
				enemyControl.health -= 20f;
			} else if (gameObject.tag == "plate2") {
				enemyControl.health -= 60f;
			} else {
				enemyControl.health -= 40f;
			}
			
	
			// Debug.Log(enemyControl.health);
		}
	}
}
