using R3;
using TMPro;
using UnityEngine;

public class CanvasView : MonoBehaviour
{
    [Header("ƒ^[ƒ“”"), SerializeField]
    TextMeshProUGUI _turnText;

    public void UpdateTurnText(int turnNumber)
    {
        _turnText.text = $"Turn: {turnNumber}";
    }
}
