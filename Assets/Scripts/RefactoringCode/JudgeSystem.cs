using TMPro;
using UnityEngine;
using static GameManager;

public class JudgeSystem : MonoBehaviour
{
    public enum CardType
    {
        King = 0,
        Slave = 1,
        Citizen = 2
    }
    CardType _playerCardsState = CardType.King;
    CardType _aiCardsState = CardType.Slave;

    // ここ要らんかも
    int playerSelectCardNumber = 0;
    int aiSelectCardNumber = 0;


    [Header("キャンバス"), SerializeField]
    GameObject _menuCanvas;

    [Header("リザルトテキスト"), SerializeField]
    TextMeshProUGUI _resultText;


    public void PlayerCardsJudge(int playerCardNumber)
    {
        // ここ要らんかも
        //playerSelectCardNumber = playerCardNumber;

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


    public void AiCardsJudge(int aiCardNumber)
    {
        // ここ要らんかも
        //aiSelectCardNumber = aiCardNumber;

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
    /// テキストの文字をWinかLoseに文字を変更
    /// </summary>
    private void ShowResultText(string resultText)
    {
        // リザルトテキスト表示
        _menuCanvas.SetActive(true);
        _resultText.text = resultText;
        _resultText.gameObject.SetActive(true);
    }
}
