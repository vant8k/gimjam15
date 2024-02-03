using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private OrderManager orderManager;
    public MenuManager menuManager;
    public GameObject platePrefab;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        orderManager = FindObjectOfType<OrderManager>();
        if (orderManager == null)
        {
            Debug.LogError("orderManager not found!");
        }
        RequestFood();
    }
    public void SetOrderManager(OrderManager manager)
    {
        orderManager = manager;
    }
    public void RequestFood()
    {
        if (menuManager != null && menuManager.menuItems.Count > 0)
        {

            MenuItem requestedItem = menuManager.menuItems[Random.Range(0, menuManager.menuItems.Count)];

           
            Debug.Log("Person requested: " + requestedItem.itemName);

            
            SpawnEmptyPlate();
        }
        else
        {
            Debug.LogWarning("Menu is empty!");
        }
    }

    void SpawnEmptyPlate()
    {
        // Instantiate an empty plate prefab (you should have a prefab for the empty plate)
        GameObject emptyPlate = Instantiate(platePrefab, transform.position, Quaternion.identity);

        // Attach the empty plate to the person (or any other logic)
        emptyPlate.transform.parent = transform;
    }

    public IEnumerator DisappearAndSpawnCoroutine()
    {
        // Optional: Add any animation or effect before disappearing
        yield return new WaitForSeconds(1.0f);

        // Destroy the current person
        Destroy(gameObject);

        // Spawn a new person after a delay
        yield return new WaitForSeconds(2.0f);
        if (orderManager != null)
        {
            orderManager.SpawnRandomPerson();
        }
    }

    public void PlateOver()
    {
        // Notify the OrderManager that the plate is released
        if (orderManager != null)
        {
            orderManager.PlateDelivered();
        }
    }

    public void ResetPlateState()
    {
        Transform plateTransform = transform.Find("PlatePrefab(Clone)"); // Assuming "PlatePrefab(Clone)" is the instantiated plate's name
        if (plateTransform != null)
        {
            plateTransform.position = plateStartPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piring"))
        {
            PlateOver();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piring"))
        {
            ResetPlateState();
        }
    }

    public void DisappearAndSpawn()
    {
        StartCoroutine(DisappearAndSpawnCoroutine());
    }
}
