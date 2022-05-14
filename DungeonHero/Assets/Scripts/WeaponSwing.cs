using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwing : MonoBehaviour
{
    private Animation anim;
 
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        swingWeapon();
    }

    void swingWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.Play("weaponSwing");
        }
    }
}
