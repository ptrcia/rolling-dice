using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[serializeField] RollDices rollDices;
    [SerializeField] GameObject info;
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
