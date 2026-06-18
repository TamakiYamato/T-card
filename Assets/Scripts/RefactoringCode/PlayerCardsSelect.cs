using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キー入力でカードを選択し、場に出す
/// </summary>
public class PlayerCardsSelect : MonoBehaviour
{
    [Header("カード"), SerializeField]
    private List<GameObject> _cardObjects;

    [Header("ターゲット"),SerializeField]
    public GameObject _cardsMoveTargetObj;

    [Header("ターゲット"), SerializeField]
    public ShowCardOutline _showCardOutline;

    [Header("ジャッジコンポーネント"), SerializeField]
    public JudgeSystem _judgeSystem;

    // カード選択の番号
    int m_cardSelectNumber = 0;

    // カードの移動速度
    static private float _cardMoveSpeed = 0.5f;



    private void Update()
    {   
        CardSelect();
    }


    private void CardSelect() 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_cardSelectNumber--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_cardSelectNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // カード選択決定
            SelectCardSetUp();

            _judgeSystem.PlayerCardsJudge(m_cardSelectNumber);
        }
        
        // カード選択の範囲を0～3に制限
        m_cardSelectNumber = Mathf.Clamp(m_cardSelectNumber, 0, 3);

        OutlineSetUp();
    }


    /// <summary>
    /// アウトラインの追加・削除
    /// </summary>
    private void OutlineSetUp()
    {
        _showCardOutline.ShowOutline(_cardObjects[m_cardSelectNumber]);
    }


    /// <summary>
    /// カードを場に出す
    /// </summary>
    private void SelectCardSetUp()
    {
        _cardObjects[m_cardSelectNumber].transform.position = Vector3.MoveTowards(
                _cardObjects[m_cardSelectNumber].transform.position,
                _cardsMoveTargetObj.transform.position,
                _cardMoveSpeed
            );
    }
}
