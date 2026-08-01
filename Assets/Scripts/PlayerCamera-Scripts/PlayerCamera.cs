using UnityEngine;

/// <summary>
/// プレイヤーカメラ
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    // カメラ感度
    private float rotationSpeed = 2.0f;

    // マウスの移動量
    private float mouse_X = 0.0f;
    private float mouse_Y = 0.0f;

    // 現在のカメラのX角度を保存
    private float nowX_Rot = 0.0f;

    // カメラの縦方向の回転の制限角度(オイラー角)
    private float RotUpLimit = -15.0f;
    private float RotDownLimit = 70.0f;

    [Header("プレイヤー"),SerializeField]
    public GameObject m_playerObj;


    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        // マウスカーソルを消す
        Cursor.visible = false;
    }


    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        CameraRotation();
    }


    /// <summary>
    /// カメラの視点処理
    /// </summary>
    void CameraRotation()
    {
        // マウスの移動量を取得する
        mouse_X = Input.GetAxis("Mouse X") * rotationSpeed;
        mouse_Y = Input.GetAxis("Mouse Y") * rotationSpeed;

        // マウスの移動量に応じて、カメラを回転させる
        transform.RotateAround(m_playerObj.transform.position, Vector3.up, mouse_X);
        transform.RotateAround(m_playerObj.transform.position, transform.right, mouse_Y);


        // カメラの縦方向の回転の反転を防ぐ
        nowX_Rot -= mouse_Y;

        // カメラの縦方向の制限
        nowX_Rot = Mathf.Clamp(nowX_Rot, RotUpLimit, RotDownLimit);

        // 制限した角度を反映(上書き)する
        Vector3 angls = transform.eulerAngles;
        angls.x = nowX_Rot;
        transform.eulerAngles = angls;
    }
}
