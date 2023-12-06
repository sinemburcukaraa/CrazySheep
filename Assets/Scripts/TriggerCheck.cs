using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public float force;
    public bool control;
    public BridgeScaleRate BridgeScaleRate;
    private void Start()
    {
        BridgeScaleRate =this.transform.parent.GetComponent<BridgeScaleRate>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sheep" && !control)//hepsi true deðilse
        {  
            if (!BridgeScaleRate.scaleCont
                || !BridgeScaleRate.rotCont
                || !BridgeScaleRate.posCont)
            {
                control = true;
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(-collision.contacts[0].normal * force, ForceMode.Impulse);

            }

        }

    }
}
