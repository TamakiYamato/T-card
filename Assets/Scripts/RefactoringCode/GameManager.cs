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


    private int? _playerCardNumber;
    private int? _aiCardNumber;


    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // キャンバスとマウスカーソルは最初は非表示
        _menuCanvas.SetActive(false);
        Cursor.visible = false;

        _canvasModel.AddTurnNumber();

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

    /// <summary>
    /// プレイヤーのカード番号をセット
    /// </summary>
    public void SetPlayerCard(int playerCardNumber = 0)
    {
        _playerCardNumber = playerCardNumber;

        TryJudge();
    }


    /// <summary>
    /// AIのカード番号をセット
    /// </summary>
    public void SetAiCard(int aiCardNumber)
    {
        _aiCardNumber = aiCardNumber;

        TryJudge();
    }


    /// <summary>
    /// 判定開始
    /// </summary>
    private void TryJudge()
    {
        if (_playerCardNumber == null || _aiCardNumber == null)
        {
            Debug.Log("ぬるぽ");
            return;
        }

        Debug.Log("のっとぬるぽ");
        // 勝敗判定
        _cardsAffinity.CardsJudge(_playerCardNumber.Value, _aiCardNumber.Value);
        var result = _cardsAffinity.CheckAndJudge();

        // 勝敗結果を表示
        switch (result)
        {
            case CardsAffinity.JudgeResult.PlayerWin:
                ShowResultText("Your Win!");
                break;
            case CardsAffinity.JudgeResult.AiWin:
                ShowResultText("You Lose...");
                break;
            case CardsAffinity.JudgeResult.Draw:
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
