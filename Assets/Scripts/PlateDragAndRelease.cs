using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateDragAndRelease : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private OrderManager orderManager;
    private PersonController currentPerson;

    void Start()
    {
        orderManager = FindObjectOfType<OrderManager>(); // Find the OrderManager in the scene
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
        if (currentPerson != null && orderManager != null)
        {

            if (IsOverPerson())
            {
                // Plate released over the person
                orderManager.PlateDelivered(); // Notify the OrderManager that the plate is delivered
            }
            else
            {
                // Plate released elsewhere
                currentPerson.ResetPlateState();
                transform.position = startPosition; // Reset the plate position
            }
    }

    bool IsOverPerson()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Person"))
            {
                // Notify the PersonController that a plate is over
                collider.GetComponent<PersonController>().PlateOver();
                return true;
            }
        }
        return false;
    }
    }
}
