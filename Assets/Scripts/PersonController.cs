using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = false;
    private bool isPlateOver = false;
    private OrderManager orderManager;

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (isPlateOver && Input.GetMouseButtonUp(0))
        {
            // Notify the OrderManager that the plate is delivered successfully
            orderManager.PlateDelivered();
        }
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void SetOrderManager(OrderManager manager)
    {
        orderManager = manager;
    }
    public void PlateOver()
    {
        isPlateOver = true;
    }
    public void ResetPlateState()
    {
        isPlateOver=false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piring"))
        {
            isPlateOver = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piring"))
        {
            isPlateOver = false;
        }
    }
}
