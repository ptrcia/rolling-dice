using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{

    [Header("Background")]
    [SerializeField] Button buttonTheme;
    [SerializeField] Sprite[] img;
    [SerializeField] GameObject background;
    private int currentThemeIndex = 0;
    public int themeBackground;

    [Header("Dice")]
    [SerializeField] Button buttonDice;
    [SerializeField] Material[] matD4;
    [SerializeField] Material[] matD6;
    [SerializeField] Material[] matD8;
    [SerializeField] Material[] matD10;
    [SerializeField] Material[] matD12;
    [SerializeField] Material[] matD20;

    [SerializeField] GameObject diceD4;
    [SerializeField] GameObject diceD6;
    [SerializeField] GameObject diceD8;
    [SerializeField] GameObject diceD10;
    [SerializeField] GameObject diceD12;
    [SerializeField] GameObject diceD20;


    private int currentThemeIndexDice = 0;

    public int themeDice;

    [Header("Icons")]
    [SerializeField] Button buttonIconReady;
    [SerializeField] Button[] buttonPlus;
    [SerializeField] Button[] buttonMinus;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI simulated;
    [SerializeField] TextMeshProUGUI RollMode;

    public void ChangeThemeBackground()
    {
         if (img.Length == 0) return;

        if(currentThemeIndex >= img.Length - 1)
        {
            currentThemeIndex = 0;
        }
        else
        {
            currentThemeIndex = currentThemeIndex + 1;
        }

        for (int i = 0; i < img.Length; i++)
         {
             if (i == currentThemeIndex)
             {
                 background.GetComponent<Image>().sprite = img[i];
                 themeBackground = i;
                 Debug.Log("Theme: " + themeBackground);
                 break;
             }
         }

        PlayerPrefs.SetInt("Theme", themeBackground);

    }

    public void ChangeThemeDice()
    {
        if (matD4.Length == 0 || matD6.Length == 0 || matD8.Length == 0 ||
            matD10.Length == 0 || matD12.Length == 0 || matD20.Length == 0) return;

        currentThemeIndexDice = (currentThemeIndexDice + 1) % matD4.Length;

        GameObject[] dice = { diceD4, diceD6, diceD8, diceD10, diceD12, diceD20 };
        Material[][] materials = { matD4, matD6, matD8, matD10, matD12, matD20 };

        for (int i = 0; i < dice.Length; i++)
        {
            if (dice[i] != null && materials[i].Length > 0)
            {
                dice[i].GetComponent<Renderer>().material = materials[i][currentThemeIndexDice];
            }
        }

        themeDice = currentThemeIndexDice;
        PlayerPrefs.SetInt("ThemeDice", themeDice);
        Debug.Log($"Applied theme index: {themeDice}");

    }

    public int GetTheme() { return themeBackground; }
    public int GetThemeDice() { return themeDice; }



}
