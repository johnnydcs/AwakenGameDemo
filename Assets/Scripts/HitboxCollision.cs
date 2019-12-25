using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "InPlay")
        {
            Destroy(this);
            Debug.Log("Card moved to InPlay. Discarding after effect.");
        }
    }
}
