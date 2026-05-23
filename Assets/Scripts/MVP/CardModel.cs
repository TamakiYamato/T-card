using R3;
using UnityEngine;

/// <summary>
/// 計算やデータの管理を行うクラス
/// </summary>
public class CardModel
{
    private readonly ReactiveProperty<int> _selectedCardIndex = new(0);    // 選択されたカードのインデックス
    //private readonly ReactiveProperty<int> _selectedCardIndex = new ReactiveProperty<int>(0);    // 選択されたカードのインデックス

    // 読み取り専用のプロパティ？
    public ReadOnlyReactiveProperty<int> SelectedCardIndex => _selectedCardIndex;    // 読み取り専用のReactiveProperty

    public void SelectCard(bool add)
    {
        // indexを進めるか後退させるかを判断する必要あり
        if(add)
        {
            _selectedCardIndex.Value++;
        }
        else
        {
            _selectedCardIndex.Value--;
        }
    }

}
