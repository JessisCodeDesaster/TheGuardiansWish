using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public float waiting;
    public GameObject thornProjectile;
    public GameObject projectile1;
    public GameObject projectile2;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0.15f,0);
    }
}
