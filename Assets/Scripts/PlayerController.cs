using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public class PlayerController : MonoBehaviour
{
    public Track trackLeft;
    public Track trackRight;

    public float moveSpeed;
    public float rotationSpeed;

    Vector3 direction;
    float angle;
    Rigidbody2D rb;


    public float health = 100f;
    public float maxHealth = 100f;
    public Healtbar healthbar;
    public GameObject hideEmenyEffect, gameOverObject;

    private void Awake()
    {
        gameOverObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthbar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"), 0f);
        float X = CnInputManager.GetAxis("Horizontal");
        float Y = CnInputManager.GetAxis("Vertical");
        angle = Mathf.Atan2(Y, X) * Mathf.Rad2Deg;
        if (angle != 0f)
            trackStart();
        else
            trackStop();

        Movement();
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed * Time.fixedDeltaTime;
    }

    void Movement()
    {
        if(direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            rb.position = transform.position;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if(health <= 0f)
        {
            Dealth();
        }
        health -= 10f;
        healthbar.SetHealth(health, maxHealth);
    }

    public void Dealth()
    {
        gameOverObject.SetActive(true);
        Instantiate(hideEmenyEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
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
