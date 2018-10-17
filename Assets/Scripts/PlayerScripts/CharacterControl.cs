using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed = 10;
    public float dashSpeed = 100;
    public float dashCooldown = .5f;
    public float dashTime = .8f;
    public GameObject weaponObj;
    private IWeapon weapon;


    private Rigidbody2D rb2d;
    

	// Use this for initialization
	void Start () {

        Debug.Log("started");
        rb2d = GetComponent<Rigidbody2D>();
        weapon = weaponObj.GetComponent<IWeapon>();
        
	}

    private float horz = 0;
    private float vert = 0;
    private bool dashStart = false;
    private float dashTimeLeft = 0;
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
        else if(Input.GetButtonDown("Fire1"))
        {
            weapon.Fire();
        }

        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private Vector2 dashDir;
    private bool dashing = false;
    private float angle;
    void FixedUpdate () {

        float updateTime = Time.deltaTime;

        Vector2 dir = new Vector2(horz, vert);
       // Debug.Log("dir:" + dir);

        if (dashStart)
        {
            Debug.Log("Dash!");
            dashDir = dir;
            dashDir.Normalize();
            dashing = true;
            rb2d.velocity = dashDir * dashSpeed;
            dashTimeLeft = dashTime;
            dashStart = false;
        }
        else if(!dashing)
        {
            rb2d.velocity = speed * dir;
            if(curDashCooldown > 0)
            {
                curDashCooldown -= updateTime;
            }
        }
        else if(dashing)
        {
            dashDir.Normalize();
            rb2d.velocity = dashDir * dashSpeed;
            dashTimeLeft -= updateTime;
            if(dashTimeLeft <= 0)
            {
                dashing = false;
                curDashCooldown = dashCooldown;
            }
        }
        Vector2 front = cursorPos - (Vector2)transform.position;
        //Debug.Log("CursorPos:" + cursorPos + " front:" + front);
        front.Normalize();

        float angleRot = Vector2.Angle(Vector2.right, front);
        if (front.y < 0)
        {
            angleRot = -angleRot;
        }

        rb2d.rotation = angleRot;
        //Debug.Log("Vel:" + rb2d.velocity);
	}
}
