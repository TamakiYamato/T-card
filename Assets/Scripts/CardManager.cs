using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("アウトラインコンポーネント"),SerializeField]
    private List<Outline> _outlineComponent;

    [Header("カード"), SerializeField]
    private List<GameObject> _cardObjects;

    GameManager _gameManager;

    // カードの移動時の目標ターゲット
    //[Header("移動時の目標ターゲット"),SerializeField]
    public GameObject _cardsMoveTargetObj;
    // カードの移動速度
    static private float _cardMoveSpeed = 0.5f;

    int m_cardSelectNumber = 0;

    bool selectFlg = false;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }


    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        if (selectFlg)
        {
            return;
        }
        ////カードを選択→場に出す////
        // TODO:if文のネストを無くす。
        if (Input.GetKeyDown(KeyCode.A))
        {
            // カードの選択
            // 数字減らす処理
            m_cardSelectNumber--;

            // リストの範囲外に行かないようにする処理
            if (m_cardSelectNumber < 0)
            {
                m_cardSelectNumber = 0;
            }

            GameObject Card = _cardObjects[m_cardSelectNumber];


            //アウトラインの追加・削除
            for (int i = 0; i < _outlineComponent.Count; i++)
            {
                if (i == m_cardSelectNumber)
                {
                    _outlineComponent[i].enabled = true;
                }
                else
                {
                    _outlineComponent[i].enabled = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // 数字増やす処理
            m_cardSelectNumber++;
            // リストの範囲外に行かないようにする処理
            if (m_cardSelectNumber > 3)
            {
                m_cardSelectNumber = 3;
            }

            for (int i = 0; i < _outlineComponent.Count; i++)
            {
                if (i == m_cardSelectNumber)
                {
                    _outlineComponent[i].enabled = true;
                }
                else
                {
                    _outlineComponent[i].enabled = false;
                }
            }

            // カードの選択
            GameObject Card = _cardObjects[m_cardSelectNumber];
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // カード選択決定
            // ここ直す
            _cardObjects[m_cardSelectNumber].transform.position = Vector3.MoveTowards(
                    _cardObjects[m_cardSelectNumber].transform.position,
                    _cardsMoveTargetObj.transform.position,
                    _cardMoveSpeed
                );

            _gameManager.PlayerCardsJudge(m_cardSelectNumber);

            selectFlg = true;
        }
    }
}
