using UnityEngine;

/// <summary>
/// カードの状態を管理するクラス
/// </summary>
public class CardsStatus : MonoBehaviour
{
    [SerializeField] private string cardName = "王様";          // 名前
    [SerializeField] private CardType cardType = CardType.King; // 属性

    // 
    public string CardName => cardName;
    public CardType CardType => cardType;

    
}
