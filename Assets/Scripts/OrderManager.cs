using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameObject personPrefab;
    public Transform spawnPoint;
    public MenuManager menuManager;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        if (menuManager == null)
        {
            Debug.LogError("MenuManager not found!");
        }

        StartCoroutine(SpawnRandomPersonRoutine());
    }

    IEnumerator SpawnRandomPersonRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f)); // Adjust the spawn interval

            SpawnRandomPerson();
        }
    }

    public void SpawnRandomPerson()
    {
        GameObject newPerson = Instantiate(personPrefab, spawnPoint.position, Quaternion.identity);
        PersonController personController = newPerson.GetComponent<PersonController>();

        
        personController.SetMenuManager(menuManager);

        personController.RequestFood();
    }
}
