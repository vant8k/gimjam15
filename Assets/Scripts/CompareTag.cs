using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareTag : MonoBehaviour
{
    public string tagToCompare;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToCompare))
        {
            Debug.Log("FIRE IN THE HOLE!!!!(True)");
        }
        else
        {
            Debug.Log("HE-HELL NAW");
        }
    }
}
