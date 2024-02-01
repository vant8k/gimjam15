using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekenLauk : MonoBehaviour
{
    private bool isMousePressed = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Vector3 initialPosition;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.enabled = false;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryActivateSprite();
        }

        if (isMousePressed)
        {
            MoveSpriteWithMouse();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
            SpawnNewInstance();
        }
    }

    private void TryActivateSprite()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        if (boxCollider.OverlapPoint(mousePosition))
        {
            spriteRenderer.enabled = true;
            isMousePressed = true;
        }
    }

    private void MoveSpriteWithMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        transform.position = mousePosition;
    }
    private void SpawnNewInstance()
    {
        GameObject newSpriteObject = Instantiate(gameObject, initialPosition, Quaternion.identity);
        newSpriteObject.GetComponent<TekenLauk>().enabled = true;
    }
}
