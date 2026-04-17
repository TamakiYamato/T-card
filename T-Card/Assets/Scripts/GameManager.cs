using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// カードの種類
    /// </summary>
    public enum Cards
    {
        King,       // 王様(0)
        Slave,      // 奴隷(1)
        Citizen,    // 市民(2)
    }


    [Header("王様カード"),SerializeField]
    public GameObject m_KingCard;

    [Header("奴隷カード"), SerializeField]
    public GameObject m_SlaveCard;

    [Header("市民カード"), SerializeField]
    public GameObject m_CitizenCard;

    //意味なし
    int a, b;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        do 
        {
            // 二人のプレイヤーがカードを選ぶ処理を書く。
            

            // カードを選ぶ処理が終わった後、勝敗を決める処理を書く。
        }
        // "do"の中身書けた後、条件式を勝敗に書き直す。
        while (a<b);
    }


    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        
    }
}
