using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public CinemachineVirtualCamera vCam1;    
    private Transform target;
    private Transform rp;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
        rp = GameObject.FindGameObjectWithTag("rp").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position == rp.position)
        {
            Debug.Log("refco");
            vCam1.Follow = null;
            vCam1.LookAt = target;
            vCam1.Follow = target;
        }
    }
}
