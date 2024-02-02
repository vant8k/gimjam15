using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject personPrefab;
    public Transform spawnPoint;
    private bool canSpawn = true;

    void Update()
    {
        CheckDrag();
    }

    public void SpawnPerson()
    {
        GameObject newPerson = Instantiate(personPrefab, spawnPoint.position, Quaternion.identity);
        PersonController personController = newPerson.GetComponent<PersonController>();
        personController.SetOrderManager(GetComponent<OrderManager>()); // Set the OrderManager reference
        personController.EnableMovement();
    }

    public void CheckDrag()
    {
        if (canSpawn && Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.CompareTag("Piring"))
            {
                SpawnPerson();
                canSpawn = false;
                StartCoroutine(EnableSpawn());
            }
        }
    }

    IEnumerator EnableSpawn()
    {
        yield return new WaitForSeconds(2f);
        canSpawn = true;
    }
}
