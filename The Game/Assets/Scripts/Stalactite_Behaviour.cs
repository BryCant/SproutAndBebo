using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite_Behaviour : MonoBehaviour
{
    public float fallSpeed = 20f;
    public Rigidbody2D rb;
    public float stalactiteDecayTime;
    private float deathTime;

    void Start()
    {
        rb.velocity = transform.right * -fallSpeed;
        deathTime = Time.time + stalactiteDecayTime;
    }
    private void Update()
    {
        if (Time.time >= deathTime)
        {
            Debug.Log("Decay");
            Destroy(gameObject);
        }
    }

   /* private void OnTriggerEnter2D(Collider2D other)
    {
        
    }*/
}
