using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateDragAndRelease : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

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

        if (IsOverPerson())
        {
            // Plate released over the person
            Debug.Log("Plate released over the person!");
            Destroy(gameObject); // or any other logic for plate disappearance
        }
        else
        {
            // Plate released elsewhere
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
                return true;
            }
        }
        return false;
    }
}
