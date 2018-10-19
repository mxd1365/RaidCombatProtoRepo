using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutRifle : MonoBehaviour, IWeapon {

    public GameObject tracerObj;
    public bool automatic = false;

    public bool IsAutomatic { get { return automatic; } set { automatic = value; } }

    public void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
   
        Debug.DrawRay(transform.position, transform.right * 100, Color.green, .1f,false);
        GameObject tracer = Instantiate(tracerObj);
        tracer.transform.position = transform.position;
        tracer.transform.rotation = transform.rotation;
        if (hit)
        {
            Debug.Log("Hit:" + hit.rigidbody.gameObject.name);
            
        }
    }
}
