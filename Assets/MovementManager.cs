using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public bool startMove;
    public SheepMovement sheepMovement;
    public static MovementManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
