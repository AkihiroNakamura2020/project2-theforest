using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
    private Rigidbody rBody;

    private void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = false; 
    }

    private void FixedUpdate()
    {
        SetLocalGravity(); 
    }

    private void SetLocalGravity()
    {
        rBody.AddForce(localGravity, ForceMode.Acceleration);
    }
}