using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_BulletBehaviour : MonoBehaviour
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
        if (Time.time >= deathTime)
        {
            Debug.Log("Decay");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Protagonist"))
        {
            Destroy(gameObject);
            Debug.Log("player hit");
        }
        else if (other.gameObject.CompareTag("platform"))
        {
            Destroy(gameObject);
        }
    }
}
