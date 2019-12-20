using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardTemplate card;

    public Text nameText, descriptionText, attDamage, magDamage, manaCostText;

    public Text upText, downText, leftText, rightText;

    public Image artworkImage;

    void Start()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;

        attDamage.text = card.attackDamage.ToString();
        magDamage.text = card.magicDamage.ToString();
        manaCostText.text = card.manaCost.ToString();

        upText.text = card.moveUp.ToString();
        downText.text = card.moveDown.ToString();
        leftText.text = card.moveLeft.ToString();
        rightText.text = card.moveRight.ToString();

        artworkImage.sprite = card.artwork;
    }
}
