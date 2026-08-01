using R3;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードの見た目を管理するクラス。
/// </summary>
public class CardView : MonoBehaviour
{
    [Header("カード"), SerializeField]
    public  GameObject[] _cardObjects;

    [Header("カードの移動ポイント"), SerializeField]
    public  Transform _cardMovePoint;

    [Header("アウトラインコンポーネント"), SerializeField]
    private Outline[] _outlineComponent;


    // スペースキーを押したときのイベントを発行するObservable
    // A、D、Space
    public Observable<Unit> _pushRightKey => 
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.D));
    public Observable<Unit> _pushLeftKey =>
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.A));
    public Observable<Unit> _pushSpaceKey =>
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space));


    public void SetHogeNumber(int cardSelectNumber) => ShowOutlineCardNumber(cardSelectNumber);


    /// <summary>
    /// カードのアウトラインを表示
    /// </summary>
    public void ShowOutlineCardNumber(int _showOutlineCardNumber)
    {

        for (int i = 0; i < _outlineComponent.Length; i++)
        {
            if (i == _showOutlineCardNumber)
            {
                _outlineComponent[i].enabled = true;

                Debug.Log($"hogeNumber: {_showOutlineCardNumber}");
            }
            else
            {
                _outlineComponent[i].enabled = false;
            }
        }
    }
}
