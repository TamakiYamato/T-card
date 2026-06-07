using System.Collections;
using System.Collections.Generic;
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

    [Header("Winテキスト"), SerializeField]
    GameObject _playerWinText;

    [Header("Loseテキスト"), SerializeField]
    GameObject _playerLoseText;

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

    private void CheckAndJudge()
    {
        // 王様勝利
        if (_playerCardsState == Cards.King && _aiCardsState == Cards.Citizen)
        {
            // WinnerPlayer
            Debug.Log("プレイヤーの勝ち");

            ShowMenuCanvas();
            ShowWinText();
        }
        else if(_playerCardsState == Cards.Citizen && _aiCardsState == Cards.Slave)
        {
            // WinnerPlayer
            Debug.Log("プレイヤーの勝ち");

            ShowMenuCanvas();
            ShowWinText();
        }
        // 奴隷勝利
        else if (_playerCardsState == Cards.King && _aiCardsState == Cards.Slave)
        {
            // WiinerAI
            Debug.Log("AIの勝ち");

            ShowMenuCanvas();
            ShowLoseText();
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

    private void ShowWinText()
    {
        // 勝利テキスト表示
        _playerWinText.SetActive(true);
    }

    private void ShowLoseText()
    {
        // 敗北テキスト表示
        _playerLoseText.SetActive(true);
    }
}
