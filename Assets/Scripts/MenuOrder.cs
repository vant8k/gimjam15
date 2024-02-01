using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOrder : MonoBehaviour
{
    public GameObject[] foodmenu;
    public GameObject orderedFood;
    public PersonController control;

    void Start()
    {
        Invoke("InstantiateRandomFood",2.5f);
    }

    void Update()
    {
        if (control.isPlateOver && Input.GetMouseButtonUp(0))
        {
            Destroy(orderedFood);
        }
    }
    // Update is called once per frame
    public void InstantiateRandomFood()
    {
        int randomNumber = Random.Range(0, foodmenu.Length);
        Vector3 fixedposition = new Vector3(-3.03f, 2.01f, 0.2f);
        orderedFood = Instantiate(foodmenu[randomNumber], fixedposition, Quaternion.identity);
    }
}
