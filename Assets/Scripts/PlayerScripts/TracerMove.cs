using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerMove : MonoBehaviour {

    public float velocity = 100f;

	void FixedUpdate ()
    {
        float update = Time.fixedDeltaTime;
        transform.position += transform.right * velocity * update;
	}
}
