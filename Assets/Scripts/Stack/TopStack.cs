using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TopStack : MonoBehaviour
{
    public float yDiff;
    Transform obj;
    public void yStack(Collider other, Transform StackPos, List<GameObject> StackList)//OBJELERÝN SIRTTA STACKLENMESÝ (domates)
    {
        Vector3 pos = Vector3.zero;
        int childCount = StackPos.childCount;
        float yPos = (childCount * yDiff);
        pos.y = yPos;

        obj = other.transform;
        obj.SetParent(StackPos);
        obj.tag = "Untagged";
        StackList.Add(other.gameObject);
        obj.DOLocalJump(pos, 1, 1, .5f);
    }
}
