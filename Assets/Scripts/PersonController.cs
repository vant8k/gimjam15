    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PersonController : MonoBehaviour
    {
        public bool isPlateOver = false;

        void Update()
        {
            if (isPlateOver && Input.GetMouseButtonUp(0))  
            {
                Debug.Log("Person: Piring hit!");
            }
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
