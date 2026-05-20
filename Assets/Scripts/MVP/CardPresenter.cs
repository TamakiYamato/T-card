using UnityEngine;

/// <summary>
/// ModelとViewを管理するクラス。
/// </summary>
public class CardPresenter : MonoBehaviour
{

    [SerializeField] private CardView _view;

    private CardModel _model = new();    // Modelの参照


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        _view._pushKey.Subscribe()
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        
    }


    private void CardSelectSetUp()
    {
        //_view.
    }
}
