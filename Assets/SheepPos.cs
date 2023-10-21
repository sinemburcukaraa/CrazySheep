using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPos : MonoBehaviour
{
    public GameObject sheep;
    public GameObject pos;
    private void Awake()
    {
        sheep.transform.position = pos.transform.position;
    }
}
