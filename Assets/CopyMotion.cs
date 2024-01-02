using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    private ConfigurableJoint cj;
    public bool mirror;

    private void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if (!mirror)
        {
            cj.targetRotation = targetLimb.rotation;
        }
        else
        {
            cj.targetRotation=Quaternion.Inverse(targetLimb.rotation);
        }
    }
}
