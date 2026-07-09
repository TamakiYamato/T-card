using R3;
using TMPro;
using UnityEngine;

public class CanvasView : MonoBehaviour
{
    [Header("ターン数"), SerializeField]
    TextMeshProUGUI _turnText;

    public void UpdateTurnText(int turnNumber)
    {
        _turnText.text = $"Turn: {turnNumber}";
    }


    //public void UpdateFadeOutAlpha(float alpha)
    //{
    //    // ここでフェードアウトのアルファ値を更新する処理を実装
    //    // 例: CanvasGroupのalphaプロパティを更新するなど
    //    _turnText.alpha = alpha;
    //}
}
