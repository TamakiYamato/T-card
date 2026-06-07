using System.Collections.Generic;
using UnityEngine;

public class AiCardManager : MonoBehaviour
{
    [Header("AIのカード"), SerializeField]
    private List<GameObject> _aiCardObjects;
    // カードの移動時の目標ターゲット
    //[Header("移動時の目標ターゲット"),SerializeField]
    public GameObject _aiCardsMoveTargetObj;
    // カードの移動速度
    private float _cardMoveSpeed = 0.5f;

    GameManager _gameManager;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        // 0～3の範囲でランダムに選出
        int m_cardSelectNumber = Random.Range(0, 3);
        _aiCardObjects[m_cardSelectNumber].transform.position = Vector3.MoveTowards(
                    _aiCardObjects[m_cardSelectNumber].transform.position,
                    _aiCardsMoveTargetObj.transform.position,
                    _cardMoveSpeed
                );

        _gameManager.AICardsCardsJudge(m_cardSelectNumber);
    }
}
