using UnityEngine;

public class CardStatus : MonoBehaviour
{
    [SerializeField] private CardType _cardType = CardType.King; // ‘®«

    public CardType type => _cardType;

}
