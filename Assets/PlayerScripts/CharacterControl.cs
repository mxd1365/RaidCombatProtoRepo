using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed = 10;
    public float dashSpeed = 100;
    public float dashCooldown = .5f;
    public float dashTime = .8f;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        Debug.Log("started");
        rb2d = GetComponent<Rigidbody2D>();
        
	}

    private float horz = 0;
    private float vert = 0;
    private bool dashStart = false;
    private float curDashCooldown = 0;
    private Vector2 cursorPos;
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && curDashCooldown <= 0 && !dashing)
        {
            dashStart = true;
        }

        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private Vector2 dashDir;
    private bool dashing = false;
    private float angle;
    void FixedUpdate () {

        float updateTime = Time.deltaTime;

        Vector2 dir = new Vector2(horz, vert);
        Debug.Log("dir:" + dir);

        if (dashStart)
        {
            Debug.Log("Dash!");
            dashDir = dir;
            dashing = true;
            rb2d.MovePosition(rb2d.position + (dashDir * dashDir * updateTime));
            curDashCooldown = dashCooldown;
            dashStart = false;
        }
        else if(!dashing)
        {
            rb2d.MovePosition(rb2d.position + (dir * speed * updateTime));

            Vector2 front = cursorPos - (Vector2)transform.position;
            Debug.Log("CursorPos:" + cursorPos +" front:" + front);
            front.Normalize();
            float angleRot = Vector2.Angle(Vector2.right, front);
            if (front.y < 0)
            {
                angleRot = -angleRot;
            }
           
            rb2d.rotation = angleRot;

        }
        else if(dashing)
        {
            rb2d.MovePosition(rb2d.position + (dashDir * dashSpeed * updateTime));
            curDashCooldown -= updateTime;
            if(curDashCooldown <= 0)
            {
                dashing = false;
            }
        }
        Debug.Log("Vel:" + rb2d.velocity);
	}
}
