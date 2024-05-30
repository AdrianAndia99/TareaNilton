
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void ChangeScene(string sceneName)
    {
        AudioManagerController.Instance.SaveAudioSettings();
        SceneManager.LoadScene(sceneName);
    }
}
