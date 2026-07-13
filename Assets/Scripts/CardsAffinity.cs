using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// カードの勝敗関係を管理するクラス
/// </summary>
public  class CardsAffinity
{
    public enum CardType
    {
        King = 0,
        Slave = 1,
        Citizen = 2
    }
    CardType _playerCardsState = CardType.King;
    CardType _aiCardsState = CardType.Slave;


    /// <summary>
    /// 選択されたカードの判定
    /// </summary>
    public void CardsJudge(int playerCardNumber = 0, int aiCardNumber = 0)
    {
        _playerCardsState = playerCardNumber == 0 ? CardType.King : CardType.Citizen;
        _aiCardsState = aiCardNumber == 0 ? CardType.Slave : CardType.Citizen;

        CheckAndJudge();
    }

    /// <summary>
    /// プレイヤーの勝利判定
    /// </summary>
    private bool IsPlayerWin()
    {
        return _playerCardsState == CardType.King && _aiCardsState == CardType.Citizen ||
               _playerCardsState == CardType.Citizen && _aiCardsState == CardType.Slave;
    }


    /// <summary>
    /// AIの勝利判定
    /// </summary>
    private bool IsAiWin()
    {
        return _playerCardsState == CardType.King && _aiCardsState == CardType.Slave;
    }


    /// <summary>
    /// 勝敗判定
    /// </summary>
    private void CheckAndJudge()
    {
        //プレイヤーの勝利
        if (IsPlayerWin())
        {
            Debug.Log("プレイヤーの勝利");
        }
        // AIの勝利
        else if (IsAiWin())
        {
            Debug.Log("AIの勝利");
        }
        // 引き分け
        else
        {
            Debug.Log("引き分け");
        }
    }
}
