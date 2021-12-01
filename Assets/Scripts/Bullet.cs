using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public GameObject hideEffect;
    public GameObject hideEmenyEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject effect;
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            effect = Instantiate(hideEmenyEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0.2f);
            EnemyKillCount.SetKillCount();
        }
        else
        {
            effect = Instantiate(hideEffect, transform.position, Quaternion.identity);
        }
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
