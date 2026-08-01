using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CanvasModel _canvasModel;
    private CardsAffinity _cardsAffinity = new CardsAffinity();

    [Header("プレイヤーのカード選択スクリプト"), SerializeField]
    PlayerCardsSelect _playerCardsSelect;

    [Header("AI選択クラス"), SerializeField]
    private AiCardsSelect _aiCardsSelect;

    [Header("キャンバス"), SerializeField]
    GameObject _menuCanvas;

    [Header("リザルトテキスト"), SerializeField]
    TextMeshProUGUI _resultText;

    [Header("カウントダウン"), SerializeField]
    CanvasManager _canvasManager;

    private CardStatus? _setPlayerCard;
    private CardStatus? _setAiCard;


    /// <summary>
    /// CanvasModelをセット
    /// </summary>
    public void SetCanvasModel(CanvasModel model)
    {
        _canvasModel = model;
    }


    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // キャンバスとマウスカーソルは最初は非表示
        _menuCanvas.SetActive(false);
        Cursor.visible = false;

        StartTurn();
    }

    private void StartTurn()
    {
        _canvasModel.AddTurnNumber();

        // AIのカードを選択
        _aiCardsSelect.SelectCard();
    }


    public void SetplayerCardsSelect(CardStatus playerCard)
    {
        _setPlayerCard = playerCard;

        Judge();
    }


    public void SetAiCardsSelect(CardStatus aiCard)
    {
        _setAiCard = aiCard;

        Judge();
    }


    private void ResetCardStetus()
    {
        _setPlayerCard = null;
        _setAiCard = null;
    }
    

    /// <summary>
    /// 判定開始
    /// </summary>
    public void Judge()
    {
        if (_setPlayerCard == null || _setAiCard == null)
        {
            return;
        }

        var winner = _cardsAffinity.Judge(_setPlayerCard.type, _setAiCard.type);


        switch (winner)
        {
            // 判定結果に応じて処理を分岐
            // プレイヤーの勝利
            case CardsAffinity.JudgeResult.PlayerWin:
                ShowResultText("Your Win!");
                break;

            // AIの勝利
            case CardsAffinity.JudgeResult.AiWin:
                ShowResultText("You Lose...");
                break;

            // 引き分け
            case CardsAffinity.JudgeResult.Draw:

                _playerCardsSelect.Disable();
                _aiCardsSelect.Disable();

                // カードの状態をリセット
                ResetCardStetus();

                StartTurn();
                break;
        }
    }


    /// <summary>
    /// テキストの文字をWinかLoseに文字を変更し、リザルトとマウスカーソルを表示
    /// <summary>
    private void ShowResultText(string resultText = "")
    {
        // カウントダウンを無効化
        _canvasManager.enabled = false;

        // リザルトとマウスカーソルを表示
        _menuCanvas.SetActive(true);
        _resultText.text = resultText;

        Cursor.visible = true;
    }
}
