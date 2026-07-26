using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CanvasModel _canvasModel;
    private CardsAffinity _cardsAffinity = new CardsAffinity();

    [Header("AI選択クラス"), SerializeField]
    private AiCardsSelect _aiCardsSelect;

    [Header("キャンバス"), SerializeField]
    GameObject _menuCanvas;

    [Header("リザルトテキスト"), SerializeField]
    TextMeshProUGUI _resultText;

    [Header("カメラスクリプト"), SerializeField]
    PlayerCamera _playerCamera;

    private CardStatus _setPlayerCard;
    private CardStatus _setAiCard;


    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // キャンバスとマウスカーソルは最初は非表示
        _menuCanvas.SetActive(false);
        Cursor.visible = false;

        //_canvasModel.AddTurnNumber();

        // AIのカードを選択
        _aiCardsSelect.SelectCard();
    }


    /// <summary>
    /// CanvasModelをセット
    /// </summary>
    public void SetCanvasModel(CanvasModel model)
    {
        _canvasModel = model;
    }


    public void SetplayerCardsSelect(CardStatus playerCard)
    {
        _setPlayerCard = playerCard;

        TryJudge();
    }


    public void SetAiCardsSelect(CardStatus aiCard)
    {
        _setAiCard = aiCard;

        TryJudge();
    }

    /// <summary>
    /// 判定開始
    /// </summary>
    public void TryJudge()
    {
        if (_setPlayerCard == null || _setAiCard == null)
        {
            return;
        }

        int winner = _cardsAffinity.Hoge(_setPlayerCard.type, _setAiCard.type);


        switch (winner)
        {
            case 2:
                ShowResultText("Your Win!");
                break;
            case 1:
                ShowResultText("You Lose...");
                break;
            case 0:
                //ShowResultText("Draw");
                break;
        }
    }


    /// <summary>
    /// テキストの文字をWinかLoseに文字を変更し、リザルトとマウスカーソルを表示
    /// <summary>
    private void ShowResultText(string resultText = "")
    {
        // リザルトとマウスカーソルを表示
        _menuCanvas.SetActive(true);
        _resultText.text = resultText;
        Cursor.visible = true;

        _playerCamera.enabled = false;
    }
}
