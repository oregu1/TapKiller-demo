using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Vector3 target;

    public float moveSpeed = 3.0f;
    public Transform bulletProjectile;
    public Transform spawnBulletPosition;
    public LayerMask aimMask;
    public Transform[] waypoints;
    public int currentWayPoint;
    public NavMeshAgent agent;

    private Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        currentWayPoint = 0;
        transform.position = waypoints[currentWayPoint].transform.position;//помещаем игрока на первую точку
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//стратовая позиция откуда будет луч

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimMask))
            {
                mouseWorldPosition = hit.point;
                Instantiate(bulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(mouseWorldPosition, Vector3.up));
            }
        }

         if(Input.GetKeyDown(KeyCode.Space))
        {
            GoToWayPoint();
        }
    }

    public void GoToWayPoint()
    {
        InerateWaypointIndex();

        target = waypoints[currentWayPoint].transform.position;
        agent.SetDestination(target);

    }

    void InerateWaypointIndex()
    {
        currentWayPoint++;
        animator.SetBool("isMoving", true);
        if (currentWayPoint == waypoints.Length)
        {
            currentWayPoint = 0;
        }
    }
}
