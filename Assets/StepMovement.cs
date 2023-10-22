using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StepMovement : MonoBehaviour
{
    Vector3 startPos;
    float target;
    public bool control;
    public bool isSettled;
    public bool moveStarted;
    private void Start()//2,46   -2,46
    {
        control = true;
        startPos = this.transform.position;
        target = startPos.y - 5;
    }

    private void Update()
    {
        if (GameManager.instance.gameSit == GameManager.GameSit.Started)
        {
            if (!moveStarted)
            {
                Move();
                moveStarted = true;
            }

            if (Input.GetMouseButtonDown(0) && control && !isSettled)
            {
                isSettled = true;
                control = false;
                DOTween.Kill(0);
                if (BlocksManager.instance.index < BlocksManager.instance.stepList.Count - 1)
                    BlocksManager.instance.NextStep(BlocksManager.instance.index += 1);


            }
            if (Input.GetMouseButtonUp(0))
                control = true;


            
        }
    }

    private void Move()
    {
        transform.DOMoveY(target, 2).SetId(0).OnComplete(() =>
        {
            transform.DOMoveY(startPos.y, 2).SetId(0).OnComplete(() =>
            {
                Move();
            });
        });
    }
}
