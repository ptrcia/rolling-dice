using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
