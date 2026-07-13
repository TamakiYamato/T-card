using R3;
using UnityEngine;

public class CanvasModel
{
    private ReactiveProperty<int> _trunNumber = new(0);    // ターン数の管理
    public ReadOnlyReactiveProperty<int> TurnNumber => _trunNumber;    // 読み取り専用のReactiveProperty


    public ReactiveProperty<float> _finallApha = new(1.0f);    // フェードアウトのアルファ値の管理
    public ReadOnlyReactiveProperty<float> FinallApha => _finallApha;    // 読み取り専用のReactiveProperty



    //private float _time = 0.0f;

    /// <summary>
    /// ターン数を増やす
    /// </summary>
    public void AddTurnNumber()
    {
        _trunNumber.Value++;
    }


    //public void TextFadeOutCalk()
    //{
    //    while (_finallApha.Value > 0.0f)
    //    {
    //        _time += Time.deltaTime;
    //        _finallApha.Value = Mathf.Lerp(1.0f, 0.0f, _time / 3.0f); // 3秒かけてフェードアウト
    //    }
    //    // テキストのalpha値を0にできている。
    //    // 処理が早すぎて見えていない？
    //}
}
