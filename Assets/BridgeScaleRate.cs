using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScaleRate : MonoBehaviour
{
    public float scaleX;
    public bool scaleCont, rotCont, posCont;
    public BoxCollider bCollider;
    public BoxCollider transitionCol;
    public float YPos;
    public void rate()
    {
        Vector3 scale = transform.localScale;
        scaleX = scale.x;

        float rot = transform.rotation.eulerAngles.z;

        float sizeZ = bCollider.size.z;
        sizeZ *= 1.2f;


        float transitionSizeZ = transitionCol.size.z;
        transitionSizeZ *= 1.2F;

        YPos = this.transform.position.y;

        if (scaleX < 4.3F)//scale oraný tamamsa ama rot deðilse sadece sona takýlsýn      
            bCollider.size = new Vector3(bCollider.size.x, bCollider.size.y, sizeZ);
        else
        {
            Debug.Log("scale ok");
            scaleCont = true;
        }

        if (rot > 300)
            rot = Mathf.Abs(rot) - 360;

        if (Mathf.Abs(rot) > 0.1f)
            transitionCol.size = new Vector3(transitionCol.size.x, transitionCol.size.y, transitionSizeZ);
        else
        {
            Debug.Log("rot ok");
            rotCont = true;
        }
        if(Mathf.Abs(YPos + (1.4f)) > 0.2)//-1.4
            bCollider.size = new Vector3(bCollider.size.x, bCollider.size.y, sizeZ);
        else
        {
            posCont= true;
            Debug.Log("pos ok");
        }
            

        MovementManager.Instance.sheepMovement.StartMovementForBridge();
    }

}
