using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Template")]
public class CardTemplate : ScriptableObject
{
    public string cardName, description;
    public Sprite artwork;
    public int attackDamage, magicDamage, manaCost;
    public int moveUp, moveDown, moveLeft, moveRight;

    void update()
    {
        cardName = artwork.name;
    }
}
