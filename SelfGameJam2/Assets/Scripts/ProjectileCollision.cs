﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit: " + collision.name);
        collision.gameObject.GetComponent<PlayerHealth>().HitPlayer();
        Destroy(gameObject);
    }
}
