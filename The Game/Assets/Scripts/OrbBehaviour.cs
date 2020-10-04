using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    public Animator animator;

    private Transform target;
    private Transform rp;

    public float catchupSpeed;
    public float stoppingDistance = 1;
    
    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
        rp = GameObject.FindGameObjectWithTag("rp").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();

        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove > 0)
        {
            animator.SetBool("Facing_Right", true);
        }
        else if (horizontalMove < 0)
        {
            animator.SetBool("Facing_Right", false);
        }

        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            animator.SetFloat("Orb_Speed", 1f);
        }
        else
        {
            animator.SetFloat("Orb_Speed", 0f);
        }
    }

    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();

        if (target.position == rp.position)
        {
            transform.position = rp.position;
        }
        else
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, catchupSpeed * Time.fixedDeltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) > 1.0f && Vector2.Distance(transform.position, target.position) < stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, (Mathf.Sqrt(Vector2.Distance(transform.position, target.position))) * 1.75f * Time.fixedDeltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < 1.0f)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, (Mathf.Sqrt(Vector2.Distance(transform.position, target.position)) / 4) * Time.fixedDeltaTime);
            }
        }

    }
}
