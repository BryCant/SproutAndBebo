using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Weapon : MonoBehaviour
{
    public AudioClip pewSound;
    AudioSource mySound;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public Animator animator;

    private void Awake()
    {
        mySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsShooting", true);
            Shoot();
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        mySound.PlayOneShot(pewSound, 14f);
    }
}
