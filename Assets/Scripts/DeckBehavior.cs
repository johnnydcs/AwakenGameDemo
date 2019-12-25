using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBehavior : MonoBehaviour
{
    public GameObject cardPrefab;

    public int deckSize = 40;
    public int handSize = 5;

    public GameObject[] deck;
    public GameObject[] hand;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDeck();
        Shuffle();
        SpawnHand();

        Button theButton = button.GetComponent<Button>();
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("*****Clicked on Deck");
        button.GetComponent<DeckBehavior>().SpawnNewHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateDeck()
    {
        deck = new GameObject[deckSize];

        for (int i = 0; i < deckSize; i++)
        {
            deck[i] = cardPrefab;
        }
    }

    void Shuffle()
    {
        Debug.Log("*****Shuffling deck.");

        System.Random random = new System.Random();
        int n = deckSize;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            GameObject temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }
    }

    void SpawnHand()
    {
        Debug.Log("*****New hand.");

        hand = new GameObject[handSize];

        for (int i = 0; i < deckSize; i++)
        {
            deck[i] = cardPrefab;
        }

        for (int i = 0; i < handSize; i++)
        {
            hand[i] = Instantiate(deck[i]) as GameObject;
            hand[i].transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        }
    }
    
    void SpawnNewHand()
    {
        // Discard old hand
        Debug.Log("*****Discarded hand.");
        for (int i = 0; i < handSize; i++)
        {
            Destroy(hand[i]);
            hand[i] = null;
        }
        
        Shuffle();

        SpawnHand();
    }
}
