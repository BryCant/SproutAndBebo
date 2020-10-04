using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_Weapon : MonoBehaviour
{
    public float shootTimeInc = 10f;
    public float nextShootTime = 0f;
    public float roboScope = 5f;

    private Transform target;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public HealthBar robo_health_bar;
    public int robo_health = 10;

    private void Start()
    {
        robo_health_bar.SetMaxHealth(robo_health);
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();

        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + shootTimeInc;
            if (Vector2.Distance(transform.position, target.position) < roboScope && target.transform.rotation == transform.rotation )
            {
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pro_bullet") && robo_health > 0)
        {
            robo_health--;
            robo_health_bar.SetHealth(robo_health);
        }
        else if (other.gameObject.CompareTag("pro_bullet") && robo_health == 0)
        {
            //Destroy();
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
