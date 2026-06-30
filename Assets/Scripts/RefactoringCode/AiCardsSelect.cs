using System.Collections.Generic;
using UnityEngine;

public class AiCardsSelect : MonoBehaviour
{
    [Header("AIのカード"), SerializeField]
    private List<GameObject> _aiCardObjects;
    
    [Header("移動時の目標ターゲット"),SerializeField]
    public GameObject _aiCardsMoveTargetObj;

    [Header("ゲームマネージャー"), SerializeField]
    public GameManager _gameManager;


    // カードの移動速度
    private float _cardMoveSpeed = 0.5f;


    public void SelectCard()
    {
        // カードのリスト範囲でランダムに選出
        int m_cardSelectNumber = Random.Range(0, _aiCardObjects.Count);
        _aiCardObjects[m_cardSelectNumber].transform.position = Vector3.MoveTowards(
                    _aiCardObjects[m_cardSelectNumber].transform.position,
                    _aiCardsMoveTargetObj.transform.position,
                    _cardMoveSpeed
                );

        _gameManager.AiCardsJudge(m_cardSelectNumber);

        _aiCardObjects.RemoveAt(m_cardSelectNumber);
    } 
}
