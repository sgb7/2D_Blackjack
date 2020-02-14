using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCards : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject PlayerArea;
    public GameObject DealerArea;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string> deck;

    /*public void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
    }*/

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
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

    void BlackjackDeal()
    {
        foreach (string card in deck)
        {
        //for (var i = 0; i < ; i++)
            GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            newCard.transform.SetParent(PlayerArea.transform, false);
            //newCard.name = card;
        }
    }

    public void OnClick()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        BlackjackDeal();
    }
}
