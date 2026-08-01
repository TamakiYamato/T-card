using System.Collections.Generic;
using UnityEngine;

public class AiCardsSelect : MonoBehaviour
{
    [Header("AIのカード"), SerializeField]
    private List<GameObject> _aiCardObjects;

    [Header("ステータス"), SerializeField]
    private List<CardStatus> _cardStatus;

    [Header("移動時の目標ターゲット"),SerializeField]
    public GameObject _aiCardsMoveTargetObj;

    [Header("ゲームマネージャー"), SerializeField]
    public GameManager _gameManager;

    // 
    private int _setCardSelectNumber = 0;

    // カードの移動速度
    private float _cardMoveSpeed = 0.5f;


    public void SelectCard()
    {
        // カードのリスト範囲でランダムに選出
        int _cardSelectNumber = Random.Range(0, _aiCardObjects.Count);
        //int _cardSelectNumber = Random.Range(1, _aiCardObjects.Count);

        // 選択したカードの番号を保存
        _setCardSelectNumber = _cardSelectNumber;

        _aiCardObjects[_cardSelectNumber].transform.position = Vector3.MoveTowards(
                    _aiCardObjects[_cardSelectNumber].transform.position,
                    _aiCardsMoveTargetObj.transform.position,
                    _cardMoveSpeed
                );

        _gameManager.SetAiCardsSelect(_cardStatus[_cardSelectNumber]);
    }


    public void Disable()
    {
        // 選択したカードを無効にする
        _aiCardObjects[_setCardSelectNumber].SetActive(false);

        // 選択したカードとそのステータスをリストから削除
        _aiCardObjects.RemoveAt(_setCardSelectNumber);
        _cardStatus.RemoveAt(_setCardSelectNumber);
    }
}
