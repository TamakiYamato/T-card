using R3;
using UnityEngine;

public class CanvasPresenter : MonoBehaviour
{
    [Header("Viewコンポーネント"), SerializeField]
    private CanvasView _view;

    private CanvasModel _model = new();    // Modelの参照


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        _model.TurnNumber.Subscribe(turnNumber =>
        {
            _view.UpdateTurnText(turnNumber);
        }).AddTo(this);
    }

    
    void Update()
    {
        
    }
}
