using R3;
using UnityEngine;

/// <summary>
/// 計算やデータの管理を行うクラス
/// </summary>
public class CardModel
{
    enum PushKeyType
    {
        AKey,       // Aキー(0)
        BKey,       // Bキー(1)
        SpaceKey,   // スペースキー(2)
    }

    const int _maxCardValue = 4;    // カードの最大数
    const int _minCardValue = 0;    // カードの最小数

    private readonly ReactiveProperty<int> _selectedCardIndex = new(0);    // 選択されたカードのインデックス

    // 読み取り専用のプロパティ？
    public ReadOnlyReactiveProperty<int> SelectedCardIndex => _selectedCardIndex;    // 読み取り専用のReactiveProperty

    public void SelectCard(bool add,bool move)
    {
        // indexを進めるか後退させるかを判断する必要あり


        // カードのインデックスを範囲内に収めるための処理
        //_selectedCardIndex.Value = Mathf.Clamp(_selectedCardIndex.Value, _minCardValue, _maxCardValue);

        if (add&&!move)
        {
            _selectedCardIndex.Value++;
        }
        else if(!add&&!move)
        {
            _selectedCardIndex.Value--;
        }
        else 
        {
            
        }
    }
}
