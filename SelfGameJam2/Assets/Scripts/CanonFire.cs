using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{

    public Rigidbody2D projectile;
    public float projectileSpeed;

    public void FireProjectile()
    {
        Rigidbody2D projectileRB = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
        projectileRB.velocity = transform.right * projectileSpeed;
    }
}
