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
    }

    public void PlayerCardsJudge(int playerCardNumber = 0)
    {
        switch (playerCardNumber)
        {
            case 0:
                Debug.Log("プレイヤーは王様を選びました");
                _playerCardsState = CardType.King;

                break;
            default:
                Debug.Log("プレイヤーは王様以外を選びました");
                _playerCardsState = CardType.Citizen;

                break;
        }

        CheckAndJudge();
    }


    public void AiCardsJudge(int aiCardNumber = 0)
    {
        switch (aiCardNumber)
        {
            case 0:
                Debug.Log("AIは奴隷を選びました");
                _aiCardsState = CardType.Slave;

                break;
            default:
                Debug.Log("AIは奴隷以外を選びました");
                _aiCardsState = CardType.Citizen;

                break;
        }
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
