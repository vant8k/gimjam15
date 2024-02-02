using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameObject[] foodMenu;
    public GameObject orderedFood;
    public SpawnManager spawnManager;
    public PersonController control;

    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        Invoke("RequestMenu", 2.5f);
    }
    public void Update()
    {
        if (control != null && control.isPlateOver && Input.GetMouseButtonUp(0))
        {
            Destroy(orderedFood);
        }
    }

    public void RequestMenu()
    {
        // Spawn a person and request a menu
        spawnManager.CheckDrag();
    }

    public void PlateDelivered()
    {
        // If the plate is delivered successfully
        Destroy(orderedFood); // Destroy the plate
        Invoke("RequestMenu", 2.5f); // Request a new menu after a delay
    }

    public void InstantiateRandomFood(Vector3 position)
    {
        int randomNumber = Random.Range(0, foodMenu.Length);
        orderedFood = Instantiate(foodMenu[randomNumber], position, Quaternion.identity);
    }
}