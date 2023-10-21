using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class SheepMovement : MonoBehaviour
{
    Rigidbody rb;

    public void StartMovementForBridge()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.right * 500);
    }
    [Button]
    public void StartMovementForStep()
    {
        Debug.Log("noluyo");
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 100);
    }

}



















//public event Action startSheepMovement;


//public void StartMovement()
//{
//    startSheepMovement += Movement;
//    startSheepMovement?.Invoke();
//}