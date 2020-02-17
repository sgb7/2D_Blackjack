using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCard : MonoBehaviour
{
    CardModel cardModel;
    int cardIndex = 0;

    public GameObject card;

    void Awake()
    {
        cardModel = card.GetComponent<CardModel>();
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 28), "Hit me!"))
        {
            cardModel.cardIndex = cardIndex;
            cardModel.ToggleFace(true);

            if(cardIndex == 52)
            {
                cardIndex = 0;
                cardModel.ToggleFace(false);
            }
            else
            {
                cardIndex++;
            }
        }
    }
}

//Debug code needs debugging
