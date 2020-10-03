using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RewardSystem : MonoBehaviour
{
    private int attempts = 1;

    public Transform resetPoint;
    public CinemachineVirtualCamera vCam1;
    public GameObject Protagonist;


    // Initiate Rewards
    public int batteries = 0;
    public int berries = 0;
    public float lightIntensityMultiplyer = 1;

    public Light2D OrbLight;

    // Pro Stats
    static public int maxCapacity = 10;
    static public int currentCapacity = 10;

    // Orb Stats
    static public int maxCharge = 10;
    static public int currentCharge = 10;
    public float drainTimeWait = 30f;
    public float nextdrainTime = 30f;

    public HealthBar ProHealthBar;
    public HealthBar OrbHealthBar;


    void Start()
    {
        ProHealthBar.SetMaxHealth(maxCapacity);
        ProHealthBar.SetHealth(currentCapacity);

        OrbHealthBar.SetMaxHealth(maxCharge);
        OrbHealthBar.SetHealth(currentCharge);
        OrbLight.intensity = batteries * (.10f * lightIntensityMultiplyer);
    }

    private void Update()
    {
        if(Time.time >= nextdrainTime && currentCharge > 0)
        {
            nextdrainTime = Time.time + drainTimeWait;

            batteries--;
            OrbLight.intensity = batteries * (.10f * lightIntensityMultiplyer);

            currentCharge = batteries;
            OrbHealthBar.SetHealth(currentCharge);
        } 
        else if (Time.time >= nextdrainTime &&  currentCharge == 0)
        {
            nextdrainTime = Time.time + drainTimeWait;

            batteries = 0;
            OrbLight.intensity = batteries * (.10f * lightIntensityMultiplyer);

            currentCharge = batteries;
            OrbHealthBar.SetHealth(currentCharge);
        }
    }

    public void ResetPlayer()
    {
        // Protagonist Reset
        if((maxCapacity - attempts) > 2)
        {
            berries = maxCapacity - attempts;
        }
        else
        {
            berries = 1;
        }
        currentCapacity = berries;
        ProHealthBar.SetHealth(currentCapacity);
        // transform.position = resetPoint.position;

        Instantiate(Protagonist, resetPoint.position, resetPoint.rotation);
        vCam1.Follow = Protagonist.transform;
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Berry") && berries < maxCapacity)
        {
            berries++;
            Destroy(other.gameObject);

            currentCapacity = berries;
            ProHealthBar.SetHealth(currentCapacity);

        }
        else if (other.gameObject.CompareTag("robo_bullet") && berries > 1)
        {
            berries--;
            currentCapacity = berries;
            ProHealthBar.SetHealth(currentCapacity);
        }
        else if (other.gameObject.CompareTag("Battery") && batteries < maxCharge)
        {
            batteries++;
            Destroy(other.gameObject);
            OrbLight.intensity = batteries * (.10f * lightIntensityMultiplyer);

            currentCharge = batteries;
            OrbHealthBar.SetHealth(currentCharge);
        }
        else if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("u ded");
            attempts++;
            ResetPlayer();
        }
        else if (other.gameObject.CompareTag("robo_bullet") && berries == 1)
        {
            Debug.Log("u ded");
            attempts++;
            ResetPlayer();
        }
    }
}
