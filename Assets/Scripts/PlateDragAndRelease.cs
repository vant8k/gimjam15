using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateDragAndRelease : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private PersonController currentPerson;
    private OrderManager orderManager;

    void Start()
    {
        orderManager = FindObjectOfType<OrderManager>(); 
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (currentPerson != null)
        {

            if (IsOverPerson())
            {
                
                orderManager.PlateDelivered();
            } 
            else
            {
                currentPerson.ResetPlateState();
            }
    }

    bool IsOverPerson()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Person"))
            {
                collider.GetComponent<PersonController>().PlateOver();
                return true;
            }
        }
        return false;
    }
    }
}
