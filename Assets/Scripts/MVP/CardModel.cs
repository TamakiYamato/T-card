using R3;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 計算やデータの管理を行うクラス
/// </summary>
public class CardModel
{
    // カードの選択状態を管理するプロパティ
    private readonly ReactiveProperty<int> _selectedCardIndex = new(0);    // 選択されたカードのインデックス
    public ReadOnlyReactiveProperty<int> SelectedCardIndex => _selectedCardIndex;    // 読み取り専用のReactiveProperty


    /// <summary>
    /// カード選択
    /// </summary>
    public void SelectCard(bool add)
    {
        // indexを進めるか後退させるかを判断する必要あり
        // カードのインデックスを範囲内に収めるための処理

        if (add)
        {
            _selectedCardIndex.Value++;
        }
        else
        {
            _selectedCardIndex.Value--;
        }

        // 三項演算子バージョン
        //_selectedCardIndex.Value += add ? 1 : -1;

    }


    /// <summary>
    /// カードの移動処理
    /// </summary>
    public void DecisionCard()
    {
        // 決定されてた
        Debug.Log("カード決定");

        // 決定するとカードの選択を行えないようにする
        
    }
}
