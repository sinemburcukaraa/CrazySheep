using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2048Match : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(initialPosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = new Vector3(0f, 2f, 0f);
    }

    private void OnMouseDrag()
    {
        Vector3 screenMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetMousePos().z);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(screenMousePos) + mousePositionOffset;
        newPosition.y = initialPosition.y + 2f; // Keep y position 2 units above initial y

        transform.position = newPosition;
    }
}
