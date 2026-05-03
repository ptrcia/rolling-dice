using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigReady : MonoBehaviour
{
    [SerializeField] private DiceSetUp diceSetUp;
    [SerializeField] private GetValueDropdown getValueDropdown;
    [SerializeField] private Toggle toggle;

    [SerializeField] private Toggle autoToggle;
    [SerializeField] private Toggle shakeToggle;

    private int isAutoValue;
    private int isShakeValue;
    private int isSimulatedValue;
    private int d4value, d6value, d8value, d10value, d12value, d20value;

    private void Start()
    {
        autoToggle.onValueChanged.AddListener(delegate { OnAutoToggleChanged(); });
        shakeToggle.onValueChanged.AddListener(delegate { OnShakeToggleChanged(); });

        if (autoToggle.isOn) shakeToggle.isOn = false;
        if (shakeToggle.isOn) autoToggle.isOn = false;

        isAutoValue = PlayerPrefs.GetInt("isAuto");
        isShakeValue = PlayerPrefs.GetInt("isShake");
        isSimulatedValue = PlayerPrefs.GetInt("isSimulated");

        autoToggle.isOn = isAutoValue == 1;
        shakeToggle.isOn = isShakeValue == 1;
        toggle.isOn = isSimulatedValue == 1;

       if (autoToggle.isOn) shakeToggle.isOn = false;
        if (shakeToggle.isOn) autoToggle.isOn = false;
        //if (toggle.isOn) toggle.isOn = false;

        Debug.Log("Loaded: isAuto(" + isAutoValue + ") isShake(" + isShakeValue + ") isSimulated(" + isSimulatedValue + ")");
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // Insert Code Here (I.E. Load Scene, Etc)
                Application.Quit();
            }
        }
    }

    private void OnAutoToggleChanged()
    {
        if (autoToggle.isOn)
        {
            shakeToggle.isOn = false; 
        }
    }

    private void OnShakeToggleChanged()
    {
        if (shakeToggle.isOn)
        {
            autoToggle.isOn = false; 
        }
    }

    private void OnDestroy()
    {
        autoToggle.onValueChanged.RemoveListener(delegate { OnAutoToggleChanged(); });
        shakeToggle.onValueChanged.RemoveListener(delegate { OnShakeToggleChanged(); });
    }

public void SetUp()
    {
        d4value = diceSetUp.GetD4();
        d6value = diceSetUp.GetD6();
        d8value = diceSetUp.GetD8();
        d10value = diceSetUp.GetD10();
        d12value = diceSetUp.GetD12();
        d20value = diceSetUp.GetD20();

        
        isSimulatedValue = toggle.isOn ? 1 : 0;
        isAutoValue = autoToggle.isOn ? 1 : 0;
        isShakeValue = shakeToggle.isOn ? 1 : 0;

        PlayerPrefs.SetInt("isAuto", isAutoValue);
        PlayerPrefs.SetInt("isShake", isShakeValue);
        PlayerPrefs.SetInt("isSimulated", isSimulatedValue);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("d4", d4value);
        PlayerPrefs.SetInt("d6", d6value);
        PlayerPrefs.SetInt("d8", d8value);
        PlayerPrefs.SetInt("d10", d10value);
        PlayerPrefs.SetInt("d12", d12value);
        PlayerPrefs.SetInt("d20", d20value);
        PlayerPrefs.Save();

        

        Debug.Log("Saved: Dices - D4(" + d4value+") D6("+ d6value + ") D8(" + d8value + ") D10(" + d10value + ") D12(" + d12value + ") D20(" + d20value + ")");

        SceneManager.LoadScene("02-diceRoller");
    }
}
