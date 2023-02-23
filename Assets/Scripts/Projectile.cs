using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem.EnhancedTouch;

public class Projectile : MonoBehaviour
{
    public Transform bulletProjectile;

    public float moveSpeed = 3.0f;

    private Rigidbody bulletRB;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletRB.velocity = transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
