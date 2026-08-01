using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("カウントダウンテキスト"), SerializeField]
    TextMeshProUGUI _selectCountText;

    private static float _limitTime = 3.0f;
    private float _selectLimitTime = _limitTime;

    public bool timeLimit = false;

    string _text = "none";

    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        _selectLimitTime -= Time.deltaTime;

        if(_selectLimitTime < 0)
        {
            timeLimit = true;
            //_selectLimitTime = 0;
            _selectLimitTime = _limitTime;
        }

        _selectCountText.text = _text = _selectLimitTime.ToString("F0");
    }
}
