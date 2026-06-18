using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Cards 
    {
        King = 0,
        Slave = 1,
        Citizen =2
    }

    Cards _playerCardsState = Cards.King;
    Cards _aiCardsState = Cards.Slave;

    // プレイヤーとAIが選択したカードの番号を格納する変数
    int playerSelectCardNumber = 0;
    int aiSelectCardNumber = 0;

    [Header("リザルトテキスト"), SerializeField]
    TextMeshProUGUI _resultText;    

    [Header("キャンバス"), SerializeField]
    GameObject _menuCanvas;

    [Header("カメラスクリプト"),SerializeField]
    PlayerCamera _playerCameraScript;

    void Start()
    {
        // カメラスクリプトを取得
        //_playerCameraScript = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
    }

    /// <summary>
    /// プレイヤーが選択したカードを取得
    /// </summary>
    public void PlayerCardsJudge(int playerCardNumber)
    {
        playerSelectCardNumber = playerCardNumber;

        switch (playerSelectCardNumber)
        {
            case 0:
                Debug.Log("プレイヤーは王様を選びました");

                _playerCardsState = Cards.King;

                break;
            default:
                Debug.Log("プレイヤーは王様以外を選びました");

                _playerCardsState = Cards.Citizen;

                break;
        }

        CheckAndJudge();
    }


    /// <summary>
    /// AIが選択したカードを取得
    /// </summary>
    public void AICardsCardsJudge(int aiCardNumber)
    {
        aiSelectCardNumber = aiCardNumber;

        switch (aiSelectCardNumber)
        {
            case 0:
                Debug.Log("AIは奴隷を選びました");

                _aiCardsState = Cards.Slave;

                break;
            default:
                Debug.Log("AIは奴隷以外を選びました");

                _aiCardsState = Cards.Citizen;

                break;
        }
    }

    /// <summary>
    /// プレイヤーの勝利判定
    /// </summary>
    /// <returns></returns>
    private bool IsPlayerWin()
    {
        return _playerCardsState == Cards.King && _aiCardsState == Cards.Citizen ||
               _playerCardsState == Cards.Citizen && _aiCardsState == Cards.Slave;
    }



    private void CheckAndJudge()
    {
        // プレイヤーの勝利
        if (IsPlayerWin())
        {
            // WinnerPlayer
            Debug.Log("Win");

            ShowMenuCanvas();
            ShowResultText("プレイヤーの勝ち");
        }
        // 奴隷勝利
        else if (_playerCardsState == Cards.King && _aiCardsState == Cards.Slave)
        {
            // WiinerAI
            Debug.Log("Lose...");
            ShowMenuCanvas();
            ShowResultText("AIの勝ち");
        }
        // 引き分け
        else
        {
            // Draw
            Debug.Log("引き分け");
        }
    }

    private void ShowMouseCursor()
    {
        Cursor.visible = true;
    }

    private void ShowMenuCanvas()
    {
        // キャンバス表示
        _menuCanvas.SetActive(true);
        // マウスカーソル表示
        ShowMouseCursor();
        // カメラの視点処理停止
        _playerCameraScript.enabled = false;
    }

    private void ShowResultText(string resultText)
    {
        // リザルトテキスト表示
        _resultText.text = resultText;
        _resultText.gameObject.SetActive(true);
    }
}
