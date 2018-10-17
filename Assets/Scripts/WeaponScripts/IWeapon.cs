using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{

    bool IsAutomatic { get; set; }
            
    void Fire(); //Shoot the weapon! PEW PEW!
}
