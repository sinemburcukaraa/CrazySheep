using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public float force;
    public bool control;
    public bool rotCont,posCont,scaleCont;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sheep" && !control)//hepsi true deðilse
        {  
            if (!MovementManager.Instance.BridgeScaleRate.scaleCont
                || !MovementManager.Instance.BridgeScaleRate.rotCont
                || !MovementManager.Instance.BridgeScaleRate.posCont)
            {
                control = true;
                Debug.Log("sheep");
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                Debug.Log(-collision.contacts[0].normal);
                rb.AddForce(-collision.contacts[0].normal * force, ForceMode.Impulse);

            }

        }

    }
}
