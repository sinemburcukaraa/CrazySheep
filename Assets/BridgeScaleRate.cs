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
        transitionSizeZ *= 1.7F;

        YPos = this.transform.position.y;

        if (scaleX < 3.4F)//scale oraný tamamsa ama rot deðilse sadece sona takýlsýn      
            bCollider.size = new Vector3(bCollider.size.x, bCollider.size.y, sizeZ);
        else
        {
            scaleCont = true;
            Debug.Log("scale ok" + scaleCont);
        }

        if (rot > 300)
            rot = Mathf.Abs(rot) - 360;

        Debug.Log(Mathf.Abs(rot) + "rot");//0
        if (Mathf.Abs(rot) > 0.4f)
            transitionCol.size = new Vector3(transitionCol.size.x, transitionCol.size.y, transitionSizeZ);
        else
        {
            rotCont = true;
            Debug.Log("rot ok" + rotCont);
        }

        if (Mathf.Abs((-1.4f) - YPos) > 0.1)//-1.4
        {
            bCollider.size = new Vector3(bCollider.size.x, bCollider.size.y, sizeZ);
            transitionCol.size = new Vector3(transitionCol.size.x, transitionCol.size.y, transitionSizeZ);

        }
        else
        {
            posCont = true;
            Debug.Log("pos ok" + posCont);
        }


        MovementManager.Instance.sheepMovement.StartMovementForBridge();
        Invoke("gameOverControl", 2);
    }
    public void gameOverControl()
    {
        Debug.Log("gfb");
        if (!scaleCont || !rotCont || !posCont)
        {
            GameManager.instance.GameOver();
        }
        else
        {
            GameManager.instance.Win();
        }

        SheepMovement.instance.control = true;
    }
}
