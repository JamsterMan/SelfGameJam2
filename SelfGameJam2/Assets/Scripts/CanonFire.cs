using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{

    public Rigidbody2D projectile;
    public float projectileSpeed;
    public bool fire;

    // Start is called before the first frame update
    void Start()
    {
        fire = true;
    }

    public void FireProjectile()
    {
        Rigidbody2D projectileRB = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
        projectileRB.velocity = transform.right * projectileSpeed;
    }
}
