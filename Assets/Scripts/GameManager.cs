using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[serializeField] RollDices rollDices;
    public void ChangeScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        //decirle que no hay nada en la lista de dices seleccionados
        //rollDices.selectedDices.Clear();
    }
}
