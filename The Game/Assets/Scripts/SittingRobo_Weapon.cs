using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingRobo_Weapon : MonoBehaviour
{
    public float shootTimeInc = 10f;
    public float currentShootTime = 0f;
    // public float roboScope = 5f;

    // private Transform target;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        // target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= currentShootTime)
        {
            currentShootTime = Time.time + shootTimeInc;
            Shoot();

            /*if (Vector2.Distance(transform.position, target.position) < roboScope && target.transform.rotation == transform.rotation )
            {
                Shoot();
            }*/
        }
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
