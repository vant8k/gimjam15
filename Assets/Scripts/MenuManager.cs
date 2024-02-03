using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MenuItem
{
    public string itemName;
    public Sprite itemImage;
    // Add other properties as needed
}

public class MenuManager : MonoBehaviour
{
    public List<MenuItem> menuItems = new List<MenuItem>();

    void Start()
    {
        // Initialize menu items
        // You can populate the list from the Inspector or through code

        // Example: Adding menu items manually (you can also do this through the Inspector)
        AddMenuItem("Burger", burgerSprite);
        AddMenuItem("Pizza", pizzaSprite);
        AddMenuItem("Salad", saladSprite);
        // Add more menu items as needed
    }

    // Method to add a menu item to the list
    public void AddMenuItem(string itemName, Sprite itemImage)
    {
        MenuItem newItem = new MenuItem
        {
            itemName = itemName,
            itemImage = itemImage
        };
        menuItems.Add(newItem);
    }

    // Example: Menu item sprites (replace these with your actual sprite assets)
    public Sprite burgerSprite;
    public Sprite pizzaSprite;
    public Sprite saladSprite;
    // Add more sprite references as needed
}
