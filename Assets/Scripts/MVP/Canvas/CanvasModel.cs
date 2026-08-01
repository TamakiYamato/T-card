using R3;
using UnityEngine;

public class CanvasModel
{
    private ReactiveProperty<int> _turnNumber = new(0);    // ターン数の管理
    public ReadOnlyReactiveProperty<int> TurnNumber => _turnNumber;    // 読み取り専用のReactiveProperty


    public ReactiveProperty<float> _finalApha = new(1.0f);    // フェードアウトのアルファ値の管理
    public ReadOnlyReactiveProperty<float> FinallApha => _finalApha;    // 読み取り専用のReactiveProperty

    //private float _time = 0.0f;


    /// <summary>
    /// ターン数を増やす
    /// </summary>
    public void AddTurnNumber()
    {
        _turnNumber.Value++;
    }


    public void TextFadeOutCalc()
    {
        //while (_finalApha.Value > 0.0f)
        //{
        //    _time += Time.deltaTime;
        //    _finalApha.Value = Mathf.Lerp(1.0f, 0.0f, _time / 3.0f); // 3秒かけてフェードアウト
        //}
    }
}
