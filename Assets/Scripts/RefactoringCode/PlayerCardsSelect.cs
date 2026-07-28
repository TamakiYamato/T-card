using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キー入力でカードを選択し、場に出す
/// </summary>
public class PlayerCardsSelect : MonoBehaviour
{
    [Header("カード"), SerializeField]
    private List<GameObject> _cardObjects;

    [Header("ステータス"), SerializeField]
    private List<CardStatus> _cardStatus;

    [Header("ターゲット"),SerializeField]
    public GameObject _cardsMoveTargetObj;

    [Header("ターゲット"), SerializeField]
    public ShowCardOutline _showCardOutline;

    [Header("ゲームマネージャー"), SerializeField]
    public GameManager _gameManager;

    [Header("カウントダウン"), SerializeField]
    public CanvasManager _canvasManager;


    // カード選択の番号
    private int _cardSelectNumber = 0;

    private int _setCardSelectNumber = 0;

    private int _maxCardSelectNumber = 3;

    // カードの移動速度
    static private float _cardMoveSpeed = 0.5f;


    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {   
        CardSelect();
    }


    /// <summary>
    /// カード選択
    /// </summary>
    private void CardSelect() 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _cardSelectNumber--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _cardSelectNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) || _canvasManager.timeLimit)
        {
            // 選択したカードの番号を保存
            _setCardSelectNumber = _cardSelectNumber;

            // カード選択決定
            SelectCardSetUp();

            _gameManager.SetplayerCardsSelect(_cardStatus[_cardSelectNumber]);

            _canvasManager.timeLimit = false;
        }
        
        // カード選択の範囲を0～3に制限
        _cardSelectNumber = Mathf.Clamp(_cardSelectNumber, 0, _maxCardSelectNumber);

        OutlineSetUp();
    }


    /// <summary>
    /// アウトラインの追加・削除
    /// </summary>
    private void OutlineSetUp()
    {
        _showCardOutline.ShowOutline(_cardObjects[_cardSelectNumber]);
    }


    /// <summary>
    /// カードを場に出す
    /// </summary>
    private void SelectCardSetUp()
    {
        _cardObjects[_cardSelectNumber].transform.position = Vector3.MoveTowards(
                _cardObjects[_cardSelectNumber].transform.position,
                _cardsMoveTargetObj.transform.position,
                _cardMoveSpeed
            );
    }


    /// <summary>
    /// 一度選択したカードを無効にする
    /// </summary>
    public void Disable()
    {
        // 選択したカードを無効にする
        _cardObjects[_setCardSelectNumber].SetActive(false);
    }
}
