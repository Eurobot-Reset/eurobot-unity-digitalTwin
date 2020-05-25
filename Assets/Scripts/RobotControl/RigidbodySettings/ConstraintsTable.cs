using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintsTable : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the some axis.
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | 
        RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
    }
}


