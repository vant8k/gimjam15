using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MergeObjects otherMergeScript = collision.gameObject.GetComponent<MergeObjects>();

        if (otherMergeScript != null)
        {
            Destroy(collision.gameObject);
            transform.localScale *= 1.1f;
        }
    }
}
