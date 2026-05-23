using R3;
using UnityEngine;

/// <summary>
/// カードの見た目を管理するクラス。
/// </summary>
public class CardView : MonoBehaviour
{
    // スペースキーを押したときのイベントを発行するObservable
    // A、D、スペース
    public Observable<Unit> _pushRightKey => 
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.D));

    public Observable<Unit> _pushLeftKey =>
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.A));
    public Observable<Unit> _pushSpaceKey =>
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space));


    public void SetHogeNumber(int cardSelectNumber) => ShowSelectCardNumber(cardSelectNumber);


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        
    }


    /// <summary>
    /// カード選択時のキー入力
    /// </summary>
    public void CardSelect()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    public void ShowSelectCardNumber(int hogeNumber)
    {
        Debug.Log($"hogeNumber: {hogeNumber}");
    }
}
