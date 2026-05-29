using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadStatScene : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainStage");
    }
}
