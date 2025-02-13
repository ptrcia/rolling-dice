using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[serializeField] RollDices rollDices;
    [SerializeField] GameObject info;


    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void ChangeScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        //decirle que no hay nada en la lista de dices seleccionados
        //rollDices.selectedDices.Clear();
    }

    public void Info()
    {
        if (info.activeInHierarchy)
        {
            info.SetActive(false);
        }
        else
        {
            info.SetActive(true);
        }
    }
}
