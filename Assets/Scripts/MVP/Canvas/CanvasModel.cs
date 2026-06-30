using R3;
using UnityEngine;

public class CanvasModel : MonoBehaviour
{
    private ReactiveProperty<int> _trunNumber = new(0);    // ターン数の管理

    public ReadOnlyReactiveProperty<int> TurnNumber => _trunNumber;    // 読み取り専用のReactiveProperty


    /// <summary>
    /// ターン数を増やす
    /// </summary>
    public void AddTurnNumber()
    {
        _trunNumber.Value++;
    }
}
