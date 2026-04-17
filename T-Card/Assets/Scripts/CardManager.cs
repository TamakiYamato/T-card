using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("カード"), SerializeField]
    private List<GameObject> _cardObjects;
    // カードの移動時の目標ターゲット
    //[Header("移動時の目標ターゲット"),SerializeField]
    public GameObject _cardsMoveTargetObj;
    // カードの移動速度
    private float _cardMoveSpeed = 0.5f;


    int m_cardSelectNumber = 0;
    int addNumber = 1;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        
    }


    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // カードの選択
            // 数字の値が変わってない、、、

            // 数字減らす処理
            m_cardSelectNumber--;
            // リストの範囲外に行かないようにする処理
            if (m_cardSelectNumber < 0)
            {
                m_cardSelectNumber = 0;
            }

            GameObject Card = _cardObjects[m_cardSelectNumber];

            Debug.Log(m_cardSelectNumber);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // 数字増やす処理
            m_cardSelectNumber++;
            // リストの範囲外に行かないようにする処理
            if (m_cardSelectNumber > 4)
            {
                m_cardSelectNumber = 4;
            }

            // カードの選択
            GameObject Card = _cardObjects[m_cardSelectNumber];

            Debug.Log(m_cardSelectNumber);
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
        }
    }
}
