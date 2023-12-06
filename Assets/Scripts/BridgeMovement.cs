using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Linq;

public class BridgeMovement : MonoBehaviour
{
    BridgeScaleRate bridgeScaleRate;
    public delegate void Movement();
    public static event Movement movement;
    public Delegate[] funcs = new Delegate[4];
    public int tapCount = 0;
    public List<int> index = new List<int>();
    float yPos;
    public bool addFunc;
    void Start()
    {
        yPos = this.transform.position.y;
        bridgeScaleRate = this.GetComponent<BridgeScaleRate>();
    }
    public void AddFuncs()
    {
        movement += ScaleMovement;
        movement += RotateMovement;
        movement += MoveUpAndDown;

        funcs = movement.GetInvocationList();
        ((Movement)funcs[index[0]]).Invoke();
    }
    public void RemoveFuncs()
    {
        movement -= ScaleMovement;
        movement -= RotateMovement;
        movement -= MoveUpAndDown;

    }
    public void Update()
    {
        if (GameManager.instance.gameSit == GameManager.GameSit.Started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tapCount++;
                DOTween.Kill(0);
                chooseFuncs();
            }

            if (!addFunc)
            {
                addFunc = true;
                AddFuncs();
            }
        }

    }

    public void chooseFuncs()
    {
        Debug.Log(index.Count);
        if (index.Count == 1)
        {
            if (tapCount == 1)
            {
                bridgeScaleRate.rate();
                RemoveFuncs();

            }
        }
        else if (index.Count == 2)
        {
            if (tapCount == 1)
                ((Movement)funcs[index[1]]).Invoke();
            if (tapCount == 2)
            {
                bridgeScaleRate.rate();
                RemoveFuncs();

            }
        }
        else if (index.Count == 3)
        {
            if (tapCount == 1)
                ((Movement)funcs[index[1]]).Invoke();
            if (tapCount == 2)
                ((Movement)funcs[index[2]]).Invoke();
            if (tapCount == 3)
            {
                bridgeScaleRate.rate();
                RemoveFuncs();
            }
        }
    }
    public float fScale, lScale;
    public void ScaleMovement()//0
    {
        transform.DOScaleX(fScale, 1).SetId(0).OnComplete(() =>
        {
            transform.DOScaleX(lScale, 1).SetId(0).OnComplete(() =>
            {
                ScaleMovement();
            });
        });
    }
    public void RotateMovement()//1
    {
        transform.DOLocalRotate(new Vector3(0, 0, 30), 2).SetId(0).OnComplete(() =>
        {
            transform.DOLocalRotate(new Vector3(0, 0, -30), 2).SetId(0).OnComplete(() =>
            {
                RotateMovement();
            });
        });
    }

    public void MoveUpAndDown()//2
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
