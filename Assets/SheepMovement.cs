using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class SheepMovement : MonoBehaviour
{
    Rigidbody rb;

    public static SheepMovement instance;
    public bool control;
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (rb.velocity.magnitude < 0.03f && control)
        {
            rb.isKinematic = true;
            GameManager.instance.GameOver();
        }
    }
    public void StartMovementForBridge()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 500);
    }
    [Button]
    public void StartMovementForStep()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 120);
        StartCoroutine(num());
    }
    IEnumerator num()
    {
        yield return new WaitForSeconds(2);
        SheepMovement.instance.control = true;
    }
}



















//public event Action startSheepMovement;


//public void StartMovement()
//{
//    startSheepMovement += Movement;
//    startSheepMovement?.Invoke();
//}