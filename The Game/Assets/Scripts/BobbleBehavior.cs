using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbleBehavior : MonoBehaviour
{

    private Transform target;

    public BuoyancyEffector2D rockFluid;
    public Rigidbody2D rockPhys;
    public BoxCollider2D fluidBox;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();

        if (Vector2.Distance(transform.position, target.position) < 20 && rockFluid.enabled == false)
        {
            Debug.Log("wobble time");
            rockFluid.enabled = true;
            rockPhys.simulated = true;
            fluidBox.enabled = true;
        }
        if (Vector2.Distance(transform.position, target.position) > 20 && rockFluid.enabled == true)
        {
            rockFluid.enabled = false;
            rockPhys.simulated = false;
            fluidBox.enabled = false;
        }
    }

}
