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
    [SerializeField] Button buttonBackgroundPallete;
    [SerializeField] Button buttonDicePallete;

    [SerializeField] Sprite[] iconReady;
    [SerializeField] Sprite[] iconPlus;
    [SerializeField] Sprite[] iconMinus;
    [SerializeField] Sprite[] backgroundPallete;
    [SerializeField] Sprite[] dicePallete;
    private Color customColor;


    [Header("Text")]
    [SerializeField] TextMeshProUGUI simulated;
    [SerializeField] TextMeshProUGUI RollMode;
    [SerializeField] TextMeshProUGUI ShakeMode;
    [SerializeField] TextMeshProUGUI AutoMode;
    [SerializeField] TextMeshProUGUI[] numbers;


    private void Start()
    {
        customColor = new Color(255f / 255f, 240f / 193f, 255f / 255f);
        // Cargar los valores guardados en PlayerPrefs
        themeBackground = PlayerPrefs.GetInt("Theme", 0);
        themeDice = PlayerPrefs.GetInt("ThemeDice", 0);

        // Aplicar el tema de fondo
        if (themeBackground >= 0 && themeBackground < img.Length)
        {
            background.GetComponent<Image>().sprite = img[themeBackground];
        }

        // Aplicar el tema de los dados
        ApplyDiceTheme(themeDice);

        Debug.Log($"STARTING Theme: {themeBackground}, ThemeDice: {themeDice}");

        Colour(themeBackground);
    }

    private void Colour(int theme)
    {
        if (themeBackground == 0)
        {
            simulated.color = Color.black;
            RollMode.color = Color.black;
            ShakeMode.color = Color.black;
            AutoMode.color = Color.black;

            buttonIconReady.image.sprite = iconReady[1];
            buttonBackgroundPallete.image.sprite = backgroundPallete[1];
            buttonDicePallete.image.sprite = dicePallete[1];

            for(int i = 0; i < buttonPlus.Length; i++)
            {
                buttonPlus[i].image.sprite = iconPlus[1];
                buttonMinus[i].image.sprite = iconMinus[1];
            }
            for(int i = 0;i< numbers.Length; i++)
            {
                numbers[i].color = Color.black;
            }

        }
        else if (themeBackground == 1 || themeBackground == 3 || themeBackground ==4)
        {

            simulated.color = Color.white;
            RollMode.color = Color.white;
            ShakeMode.color = Color.white;
            AutoMode.color = Color.white;

            buttonIconReady.image.sprite = iconReady[0];
            buttonBackgroundPallete.image.sprite = backgroundPallete[0];
            buttonDicePallete.image.sprite = dicePallete[0];

            for (int i = 0; i < buttonPlus.Length; i++)
            {
                buttonPlus[i].image.sprite = iconPlus[0];
                buttonMinus[i].image.sprite = iconMinus[0];
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i].color = Color.white;
            }

        }
        else if(themeBackground == 2)
        {

            simulated.color = customColor;
            RollMode.color = customColor;
            ShakeMode.color = customColor;
            AutoMode.color = customColor;


            buttonIconReady.image.sprite = iconReady[0];
            buttonBackgroundPallete.image.sprite = backgroundPallete[0];
            buttonDicePallete.image.sprite = dicePallete[0];

            for (int i = 0; i < buttonPlus.Length; i++)
            {
                buttonPlus[i].image.sprite = iconPlus[0];
                buttonMinus[i].image.sprite = iconMinus[0];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i].color = customColor;
            }
        }
    }


    public void ChangeThemeBackground()
    {
        if (img.Length == 0) return;

        if (currentThemeIndex >= img.Length - 1)
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
        Colour(themeBackground);

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
        Debug.Log($"Applied theme dice: {themeDice}");
    }
    private void ApplyDiceTheme(int themeIndex)
    {
        GameObject[] dice = { diceD4, diceD6, diceD8, diceD10, diceD12, diceD20 };
        Material[][] materials = { matD4, matD6, matD8, matD10, matD12, matD20 };

        for (int i = 0; i < dice.Length; i++)
        {
            if (dice[i] != null && materials[i].Length > 0)
            {
                dice[i].GetComponent<Renderer>().material = materials[i][themeIndex];
            }
        }
    }

    //public int GetTheme() { return themeBackground; }
    //public int GetThemeDice() { return themeDice; }

}