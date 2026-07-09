using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードのデータを管理
/// </summary>
public enum CardType
{
    King,
    Slave,
    Citizen
}


[CreateAssetMenu(menuName = "Cards_Data")]
public class Card : ScriptableObject
{
    public string cardName;

    public CardType cardType;

    [Header("カードオブジェクト")]
    public GameObject CardObjects;
}
