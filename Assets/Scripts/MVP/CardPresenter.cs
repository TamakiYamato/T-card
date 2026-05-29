using R3;
using UnityEngine;

/// <summary>
/// ModelとViewを管理するクラス。
/// </summary>
public class CardPresenter : MonoBehaviour
{

    [Header("Viewコンポーネント"),SerializeField]
    private CardView _view;

    private CardModel _model = new();    // Modelの参照


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        // A、D、スペースキーが押されたときのイベントを購読して、ModelのSelectCardメソッドを呼び出す
        _view._pushRightKey.Subscribe(_ =>
            {
                _model.SelectCard(true,false); // 例: カードのインデックス0を選択
            })
        .AddTo(this);

        _view._pushLeftKey.Subscribe(_ =>
            {
                _model.SelectCard(false,false); // 例: カードのインデックス0を選択
            })
        .AddTo(this);
        _view._pushSpaceKey.Subscribe(_ =>
        {
            _model.SelectCard(true,false); // 例: カードのインデックス0を選択
        })
        .AddTo(this);

        // 選択しているカードの番号を取得してViewで表示する
        GetSelectCardNumber();
    }


    /// <summary>
    /// ModelとViewの接続を行うメソッド
    /// </summary>
    private void GetSelectCardNumber()
    {
        _model.SelectedCardIndex.Subscribe(_view.ShowSelectCardNumber);
    }

    private void CardSelectSetUp()
    {
        // カードの移動処理
        //public ReadOnlyReactiveProperty<float> SelectCardPoint => 
    }
}
