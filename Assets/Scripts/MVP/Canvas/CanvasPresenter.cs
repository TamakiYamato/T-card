using R3;
using UnityEngine;

public class CanvasPresenter : MonoBehaviour
{
    [Header("Viewコンポーネント"), SerializeField]
    private CanvasView _view;

    [Header("GameManager"), SerializeField]
    private GameManager _gameManager;

    private CanvasModel _model = new();    // Modelの参照


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        _gameManager.SetCanvasModel(_model);

        _model.TurnNumber.Subscribe(turnNumber =>
        {
            _view.UpdateTurnText(turnNumber);
        }).AddTo(this);
    }
}
