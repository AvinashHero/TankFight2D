using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Track trackLeft;
    public Track trackRight;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float rotationSpeed = 200f;

    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void trackStart()
    {
        trackLeft.animator.SetBool("IsMoving", true);
        trackRight.animator.SetBool("IsMoving", true);
    }

    void trackStop()
    {
        trackLeft.animator.SetBool("IsMoving", false);
        trackRight.animator.SetBool("IsMoving", false);
    }
}
