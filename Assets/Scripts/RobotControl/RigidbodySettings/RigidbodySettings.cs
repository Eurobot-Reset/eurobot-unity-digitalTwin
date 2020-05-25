using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Expose center of mass to allow it to be set from the inspector
// Expose tensor of inertia to allow adjustment from the inspector
// Resets the inertia tensor to be the coordinate system of the transform
public class RigidbodySettings : MonoBehaviour
{
    public Vector3 centerOfMass;
    public Vector3 inertiaTensor;
    public Quaternion inertiaTensorRotation;
    
    public Rigidbody rb;

    void Start()
    {   
        inertiaTensorRotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        rb.inertiaTensor = inertiaTensor;
        rb.inertiaTensorRotation = inertiaTensorRotation;
    }
}