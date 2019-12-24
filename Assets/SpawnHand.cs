using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHand : MonoBehaviour
{
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 25; i++)
        {
            if (i % 5 == 0)
            {
                GameObject newCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newCard.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
            }
        }
    }
}
