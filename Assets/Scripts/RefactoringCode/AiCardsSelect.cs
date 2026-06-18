using System.Collections.Generic;
using UnityEngine;

public class AiCardsSelect : MonoBehaviour
{
    [Header("AIのカード"), SerializeField]
    private List<GameObject> _aiCardObjects;
    
    [Header("移動時の目標ターゲット"),SerializeField]
    public GameObject _aiCardsMoveTargetObj;

    [Header("ジャッジコンポーネント"), SerializeField]
    public JudgeSystem _judgeSystem;


    // カードの移動速度
    private float _cardMoveSpeed = 0.5f;


    void Start()
    {
        // 0～3の範囲でランダムに選出
        int m_cardSelectNumber = Random.Range(0, 3);
        _aiCardObjects[m_cardSelectNumber].transform.position = Vector3.MoveTowards(
                    _aiCardObjects[m_cardSelectNumber].transform.position,
                    _aiCardsMoveTargetObj.transform.position,
                    _cardMoveSpeed
                );

        _judgeSystem.AiCardsJudge(m_cardSelectNumber);
    }
}
