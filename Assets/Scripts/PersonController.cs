using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private OrderManager orderManager;
    public MenuManager menuManager;
    public GameObject platePrefab;
    private Vector3 plateStartPosition;

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
    public void SetMenuManager(MenuManager manager)
    {
        menuManager = manager;
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
        
        GameObject emptyPlate = Instantiate(platePrefab, transform.position, Quaternion.identity);

        
        emptyPlate.transform.parent = transform;
    }

    public IEnumerator DisappearAndSpawnCoroutine()
    {
       
        yield return new WaitForSeconds(1.0f);

       
        Destroy(gameObject);

   
        yield return new WaitForSeconds(2.0f);
        if (orderManager != null)
        {
            orderManager.SpawnRandomPerson();
        }
    }

    public void PlateOver()
    {
       
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
