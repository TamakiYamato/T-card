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
    /// Awake
    /// </summary>
    private void Awake()
    {
        _gameManager.SetCanvasModel(_model);
    }

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        _model.TurnNumber.Subscribe(turnNumber =>
        {
            _view.UpdateTurnText(turnNumber);
        }).AddTo(this);

        _model.FinallApha.Subscribe(alpha =>
        {
            _view.UpdateFadeOutAlpha(alpha);
        }).AddTo(this);
    }
}
