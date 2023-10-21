using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Linq;

public class BridgeMovement : MonoBehaviour
{
    public delegate void Movement();
    public static event Movement movement;
    Delegate[] funcs = new Delegate[4];
    public int tapCount = 0;
    public List<int> index = new List<int>();
    float yPos;
    void Start()
    {

        yPos = this.transform.position.y;
        AddFuncs();
    }
    public void AddFuncs()
    {
        movement += ScaleMovement;
        movement += RotateMovement;
        movement += MoveUpAndDown;

        funcs = movement.GetInvocationList();
        ((Movement)funcs[index[0]]).Invoke();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tapCount++;
            DOTween.Kill(0);
            chooseFuncs();
        }
    }

    public void chooseFuncs()
    {
        if (index.Count == 1)
        {
            if (tapCount == 1)
                MovementManager.Instance.BridgeScaleRate.rate();
        }
        else if (index.Count == 2)
        {
            if (tapCount == 1)
                ((Movement)funcs[index[1]]).Invoke();
            if (tapCount == 2)
                MovementManager.Instance.BridgeScaleRate.rate();
        }
        else if (index.Count == 3)
        {
            if (tapCount == 1)
                ((Movement)funcs[index[1]]).Invoke();
            if (tapCount == 2)
                ((Movement)funcs[index[2]]).Invoke();
            if (tapCount == 3)
                MovementManager.Instance.BridgeScaleRate.rate();
        }
    }
    public void ScaleMovement()
    {
        transform.DOScaleX(4.35f, 1).SetId(0).OnComplete(() =>
        {
            transform.DOScaleX(0.5f, 1).SetId(0).OnComplete(() =>
            {
                ScaleMovement();
            });
        });
    }

    public void RotateMovement()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 30), 2).SetId(0).OnComplete(() =>
        {
            transform.DOLocalRotate(new Vector3(0, 0, -30), 2).SetId(0).OnComplete(() =>
            {
                RotateMovement();
            });
        });
    }
    public void MoveUpAndDown()
    {
        transform.DOLocalMoveY(yPos + 1, 2).SetId(0).OnComplete(() =>
        {
            transform.DOLocalMoveY(yPos - 1, 2).SetId(0).OnComplete(() =>
            {
                MoveUpAndDown();
            });

        });
    }

}
