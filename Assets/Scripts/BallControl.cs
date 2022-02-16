using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    void Start()
    {
        //Start the coroutine we define below named WaitAndDestroy.
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2);
		Destroy(gameObject);
    }
}
