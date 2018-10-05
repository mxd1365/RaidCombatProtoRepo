using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        Debug.Log("started");
        rb2d = GetComponent<Rigidbody2D>();
	}

    private float horz;
    private float vert;
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");

        float vert = Input.GetAxis("Vertical");
    }


    void FixedUpdate () {

        

        Vector2 dir = new Vector2(horz, vert);
        dir.Normalize();
        Debug.Log("dir:" + dir);

        rb2d.MovePosition(rb2d.position + (dir * speed));
        Debug.Log("Vel:" + rb2d.velocity);
	}
}
