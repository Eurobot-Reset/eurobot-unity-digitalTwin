using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintsRobot : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the some axis.
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints |= RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
