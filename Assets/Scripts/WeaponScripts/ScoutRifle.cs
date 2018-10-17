using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutRifle : MonoBehaviour, IWeapon {

    public bool automatic = false;

    public bool IsAutomatic { get { return automatic; } set { automatic = value; } }

    public void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
   
        Debug.DrawRay(transform.position, transform.right * 100, Color.green, .1f,false);
        if (hit)
        {
            Debug.Log("Hit:" + hit.rigidbody.gameObject.name);
            
        }
    }
}
