using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigReady : MonoBehaviour
{
    [SerializeField] private DiceSetUp diceSetUp;
    [SerializeField] private GetValueDropdown getValueDropdown;
    [SerializeField] private Toggle toggle;
    private int isSimulatedValue;
    private int d4value, d6value, d8value, d10value, d12value, d20value;

    public void SetUp()
    {
        d4value = diceSetUp.GetD4();
        d6value = diceSetUp.GetD6();
        d8value = diceSetUp.GetD8();
        d10value = diceSetUp.GetD10();
        d12value = diceSetUp.GetD12();
        d20value = diceSetUp.GetD20();

        toggle = toggle.GetComponent<Toggle>();
        isSimulatedValue = toggle.isOn ? 1 : 0;

        PlayerPrefs.SetInt("d4", d4value);
        PlayerPrefs.SetInt("d6", d6value);
        PlayerPrefs.SetInt("d8", d8value);
        PlayerPrefs.SetInt("d10", d10value);
        PlayerPrefs.SetInt("d12", d12value);
        PlayerPrefs.SetInt("d20", d20value);

        PlayerPrefs.SetInt("isSimulated", isSimulatedValue);

        Debug.Log("Saved: Dices - D4(" + d4value+") D6("+ d6value + ") D8(" + d8value + ") D10(" + d10value + ") D12(" + d12value + ") D20(" + d20value + ")");

        SceneManager.LoadScene("02-diceRoller");
    }
}
