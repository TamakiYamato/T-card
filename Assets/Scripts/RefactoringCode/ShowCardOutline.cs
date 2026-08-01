using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 引数を受け取って、カードのアウトラインを表示
/// </summary>
public class ShowCardOutline : MonoBehaviour
{
    [Header("カード"), SerializeField]
    private List<GameObject> _allCards;

    [Header("ゲームマネージャー"), SerializeField]
    public GameManager _gameManager;


    public void ShowOutline(GameObject seletCard)
    {
        foreach(var card in _allCards)
        {
            card.GetComponent<Outline>().enabled = (card == seletCard);
        }
    }
}
