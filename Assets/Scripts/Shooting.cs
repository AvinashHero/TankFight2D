using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public float fireCoolDown;
    public float bulletAddForce = 20f;

    private bool isFired;

    private float coolDownTimer = Mathf.Infinity;
    private void Update()
    {
        if (isFired && coolDownTimer > fireCoolDown)
        {
            Shoot();
        }

        coolDownTimer += Time.deltaTime;
    }

    public void PointerDown()
    {
        isFired = true;
    }
    public void PointerUp()
    {
        isFired = false;
    }


    public void Shoot()
    {
        audioSource.PlayOneShot(audioClip);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletAddForce, ForceMode2D.Impulse);
        coolDownTimer = 0f;
    }


}
