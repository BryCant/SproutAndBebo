using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public Rigidbody2D rb;
    public float bulletDecayTime;
    private float deathTime;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        deathTime = Time.time + bulletDecayTime;
    }

    private void Update()
    {
        if(Time.time >= deathTime)
        {
            Debug.Log("Decay");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("platform"))
        {
            Destroy(gameObject);
        }
    }
}
