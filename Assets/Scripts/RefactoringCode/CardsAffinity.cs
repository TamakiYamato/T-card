using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// カードの勝敗関係を管理するクラス
/// </summary>
public  class CardsAffinity
{
    public enum JudgeResult
    {
        PlayerWin,
        AiWin,
        Draw
    }


    public int Hoge(CardType playerCardType, CardType aiCardType)
    {
        if(playerCardType == CardType.King && aiCardType == CardType.Citizen ||
           playerCardType == CardType.Citizen && aiCardType == CardType.Slave)
        {
            return 2;
        }

        if(playerCardType == CardType.King && aiCardType == CardType.Slave)
        {
            return 1;
        }

        return 0;


    }
}
