using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private DealCards dealCards;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = DealCards.GenerateDeck();
        dealCards = FindObjectOfType<DealCards>();

        int i = 0;
        foreach(string card in deck)
        {
            if(this.name == card)
            {
                cardFace = dealCards.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<spriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }
}
