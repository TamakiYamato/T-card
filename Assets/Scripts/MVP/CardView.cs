using R3;
using UnityEngine;

/// <summary>
/// カードの見た目を管理するクラス。
/// </summary>
public class CardView : MonoBehaviour
{
    // スペースキーを押したときのイベントを発行するObservable
    public Observable<Unit> _pushKey => 
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space));

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
}
