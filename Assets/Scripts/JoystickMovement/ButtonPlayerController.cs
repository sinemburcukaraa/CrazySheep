using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ButtonPlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

     Rigidbody rb;
    bool isPressed = false;
    public GameObject player;
    public float force;
    public Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPressed)
        {
            player.transform.Translate(direction * force * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    
}
