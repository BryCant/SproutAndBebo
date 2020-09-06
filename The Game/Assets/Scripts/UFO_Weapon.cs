using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Weapon : MonoBehaviour
{
    public float shootTimeInc = 10f;
    public float nextShootTime = 0f;
    public float roboScope = 10f;

    private Transform target;

    public Transform LfirePoint;
    public Transform RfirePoint;
    public GameObject bulletPrefab;

    public HealthBar ufo_health_bar;
    public int ufo_health = 10;

    private void Start()
    {
        ufo_health_bar.SetMaxHealth(ufo_health);
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + shootTimeInc;
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pro_bullet") && ufo_health > 0)
        {
            ufo_health--;
            ufo_health_bar.SetHealth(ufo_health);
        }
        else if (other.gameObject.CompareTag("pro_bullet") && ufo_health == 0)
        {
            //Destroy();
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, LfirePoint.position, LfirePoint.rotation);
        Instantiate(bulletPrefab, RfirePoint.position, RfirePoint.rotation);
    }
}
