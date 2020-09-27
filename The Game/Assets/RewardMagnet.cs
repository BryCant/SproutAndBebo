using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMagnet : MonoBehaviour
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
