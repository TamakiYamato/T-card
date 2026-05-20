using R3;
using UnityEngine;

/// <summary>
/// 計算やデータの管理を行うクラス
/// </summary>
public class CardModel : MonoBehaviour
{
    // カードの種類(enum→定数)
    public enum Cards
    {
        King,       // 王様
        Slave,      // 奴隷
        Citizen,    // 市民
    }
    // 配列のみ作成
    // 代入はStart()で行う
    private ReactiveProperty<GameObject>[] _cardNumber;

    // 公開
    public ReadOnlyReactiveProperty<GameObject>[] CardNumber => _cardNumber;


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        // 配列にEnumのカードの種類を入れる処理
        var enumValues = System.Enum.GetValues(typeof(Cards));
        // _cardNumberの配列を実体化
        _cardNumber = new ReactiveProperty<GameObject>[enumValues.Length];
    }


    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        
    }
}
