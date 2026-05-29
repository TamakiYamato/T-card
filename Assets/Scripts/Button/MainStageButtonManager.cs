using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStageButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnClickReStart()
    {
        SceneManager.LoadScene("MainStage");
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
