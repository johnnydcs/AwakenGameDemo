﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBehavior : MonoBehaviour
{
    public List<string> deck;
    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public static string[] classTypes = new string[] { "Saber", "Archer", "Caster" }; //, "Lancer", "Rider", "Assassin", "Ruler", "Avenger"};
    public static string[] classRank = new string[] { "Gold", "Silver", "Bronze" };
    public List<string> spriteNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        DealCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();

        for (int i = 0; i < cardFaces.Length; i++)
        {
            spriteNames.Add(cardFaces[i].name);
        }
        
        foreach (string ct in classTypes)
        {
            foreach (string sn in spriteNames)
            {
                newDeck.Add(ct + " " + sn);
            }
        }

        return newDeck;
    }

    public void DealCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        foreach (string c in deck)
        {
            print(c);
        }
        createCardsInDeck();
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void createCardsInDeck()
    {
        foreach (string card in deck)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            newCard.name = card;
        }
    }
}