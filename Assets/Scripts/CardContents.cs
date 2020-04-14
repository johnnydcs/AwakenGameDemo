using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContents : MonoBehaviour
{
    public CardTemplate[] card;

    public Text nameText, descriptionText, attDamage, magDamage, manaCostText;

    public Text upText, downText, leftText, rightText;

    public Image artworkImage;

    int k;

    void Start()
    {
        // assign a card template from the template array
        k = Random.Range(0, card.Length);

        nameText.text = card[k].cardName;
        descriptionText.text = card[k].description;

        attDamage.text = card[k].attackDamage.ToString();
        magDamage.text = card[k].magicDamage.ToString();
        manaCostText.text = card[k].manaCost.ToString();

        upText.text = card[k].moveUp.ToString();
        downText.text = card[k].moveDown.ToString();
        leftText.text = card[k].moveLeft.ToString();
        rightText.text = card[k].moveRight.ToString();

        artworkImage.sprite = card[k].artwork;

        //Debug.Log("CardTitle: " + nameText.text);
    }
}
