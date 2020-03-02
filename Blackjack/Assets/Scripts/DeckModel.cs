using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckModel : MonoBehaviour
{
    List<int> cards;

    public IEnumerable<int> GetCards()
    {
        foreach(int i in cards)
        {
            yield return i;
        }
    }

    public int Pop()
    {
        int temp = cards[0];
        cards.RemoveAt(0);
        return temp;
    }

    public void Push(int card)
    {
        cards.Add(card);
    }

    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    public void CreateDeck()
    {
        cards.Clear();

        for(int i = 0; i < 52; i++)
        {
            cards.Add(i);
        }

        Shuffle();
    }

    void Awake()
    {
        cards = new List<int>();
        CreateDeck();
    }
}
