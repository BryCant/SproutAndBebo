using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStalactites : MonoBehaviour
{

    public float delayTime = 5;
    public float nextFallTime;
    public float spawnTime;

    public int minProximity = 17;
    public int maxProximity = 22;

    public GameObject fallingStalactite;
    public GameObject crumbles;
    private Transform target;

    private bool carryOn = true;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minProximity && Vector2.Distance(transform.position, target.position) < maxProximity)
        {
            Debug.Log("close");
            if (carryOn)
            {
                StartCoroutine(Fall());
                carryOn = false;
            }
        }
    }

    IEnumerator Fall()
    {
        Instantiate(crumbles, transform.position, transform.rotation);
        yield return new WaitForSeconds(delayTime);
        Debug.Log("closer");
        Instantiate(fallingStalactite, transform.position, fallingStalactite.transform.rotation);
        yield return new WaitForSeconds(delayTime * 2);
        carryOn = true;
    }
}
