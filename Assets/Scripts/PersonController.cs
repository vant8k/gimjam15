    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PersonController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private bool canMove = false;
        public bool isPlateOver = false;
        public MenuOrder menu;
        private string menuTag;
        private GameObject orderedFood;

        void Start()
        {
            orderedFood = menu.orderedFood;
            menuTag = orderedFood.tag;
        }
        void Update()
        {
            if (canMove)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            if (isPlateOver && Input.GetMouseButtonUp(0))  
            {
                Debug.Log("Person: Piring hit!");
            }
        }

        public void EnableMovement()
        {
            canMove = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Piring"))
            {
                isPlateOver = true;
            }

            if (other.CompareTag("Piring"))
            {
                Debug.Log("FIRE IN THE HOLE!!!"+ menuTag);
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
