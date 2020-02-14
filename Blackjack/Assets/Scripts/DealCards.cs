using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCards : MonoBehaviour
{
    //Use Resources.Load to assign sprite to certain cards? (Note: Need to make a Resources folder and place sprites in
    // it if I want to do this. This is also an option: this.GetComponent<SpriteRenderer>().sprite = someSprite
    //Two seperate prefabs -- a cardBack with just the one sprite, and a cardFront with the various sprites.
    //Have cardBack hide cardFront when the cardBack needs to be shown, and get rid of it or add it to "flip."
    //Create a seperate script called CreateDeck for creating the deck, and then implement it in DealCards?

    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject PlayerArea;
    public GameObject DealerArea;
    public GameObject CardStack;
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
        //For adding in additional decks, make a variable deck_num somewhere and add a for loop here, maybe?
        // for(var i = 0; i < deck_num; i++)
        foreach (string card in deck)
        {
            GameObject stackedCards = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            stackedCards.transform.SetParent(CardStack.transform, false);
            stackedCards.name = card;
            stackedCards.GetComponent<Selectable>().faceUp = true;
        }

        /*for(var i = 0; i < 2; i++)
        {
            GameObject playerCards = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            playerCards.transform.SetParent(PlayerArea.transform, false);

            GameObject dealerCards = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            dealerCards.transform.SetParent(DealerArea.transform, false);

            GameObject stackedCards = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            stackedCards.transform.SetParent(CardStack.transform, false);
        }*/
    }

    public void OnClick()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        BlackjackDeal();
    }
}
