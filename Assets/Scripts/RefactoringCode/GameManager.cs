using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum CardType
    {
        King = 0,
        Slave = 1,
        Citizen = 2
    }
    CardType _playerCardsState = CardType.King;
    CardType _aiCardsState = CardType.Slave;

    [Header("AI選択クラス"), SerializeField]
    private AiCardsSelect _aiCardsSelect;

    [Header("キャンバス"), SerializeField]
    GameObject _menuCanvas;

    [Header("リザルトテキスト"), SerializeField]
    TextMeshProUGUI _resultText;

    [Header("リザルトテキスト"), SerializeField]
    PlayerCamera _playerCamera;


    private void Start()
    {
        // キャンバスとマウスカーソルは最初は非表示
        _menuCanvas.SetActive(false);
        Cursor.visible = false;

        StartTurn();
    }


    private void StartTurn()
    {
        // AIのカードを選択
        _aiCardsSelect.SelectCard();
    }


    public void PlayerCardsJudge(int playerCardNumber = 0)
    {
        _playerCardsState = playerCardNumber == 0 ? CardType.King : CardType.Citizen;

        CheckAndJudge();
    }


    public void AiCardsJudge(int aiCardNumber = 0)
    {
        _aiCardsState = aiCardNumber == 0 ? CardType.Slave : CardType.Citizen;
    }


    /// <summary>
    /// プレイヤーの勝利判定
    /// </summary>
    /// <returns></returns>
    private bool IsPlayerWin()
    {
        return _playerCardsState == CardType.King && _aiCardsState == CardType.Citizen ||
               _playerCardsState == CardType.Citizen && _aiCardsState == CardType.Slave;
    }


    /// <summary>
    /// AIの勝利判定
    /// </summary>
    /// <returns></returns>
    private bool IsAiWin()
    {
        return _playerCardsState == CardType.King && _aiCardsState == CardType.Slave;
    }


    /// <summary>
    /// 勝敗判定
    /// </summary>
    private void CheckAndJudge()
    {
        // プレイヤーの勝利
        if (IsPlayerWin())
        {
            // WinnerPlayer
            Debug.Log("プレイヤーの勝ち");
            //ShowMenuCanvas();
            ShowResultText("Your Win!");
        }
        // AIの勝利
        else if (IsAiWin())
        {
            // WiinerAI
            Debug.Log("AIの勝ち");
            //ShowMenuCanvas();
            ShowResultText("Your Lose...");
        }
        // 引き分け
        else
        {
            // Draw
            Debug.Log("引き分け");

            StartTurn();
        }
    }


    /// <summary>
    /// テキストの文字をWinかLoseに文字を変更し、リザルトとマウスカーソルを表示
    /// </summary>
    private void ShowResultText(string resultText = "")
    {
        // リザルトとマウスカーソルを表示
        _menuCanvas.SetActive(true);
        _resultText.text = resultText;
        Cursor.visible = true;

        _playerCamera.enabled = false;
    }
}
