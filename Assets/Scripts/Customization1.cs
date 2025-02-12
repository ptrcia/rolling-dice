using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class Customization1 : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] Material[] img;
    [SerializeField] GameObject background;
    int theme;

    [Header("Dice")]
    [SerializeField] Material[] matD4;
    [SerializeField] Material[] matD6;
    [SerializeField] Material[] matD8;
    [SerializeField] Material[] matD10;
    [SerializeField] Material[] matD12;
    [SerializeField] Material[] matD20;

    List<GameObject> diceD4 = new List<GameObject>();
    List<GameObject> diceD6 = new List<GameObject>();
    List<GameObject> diceD8 = new List<GameObject>();
    List<GameObject> diceD10 = new List<GameObject>();
    List<GameObject> diceD12 = new List<GameObject>();
    List<GameObject> diceD20 = new List<GameObject>();

    int themeDice;

    [Header("Icons")]
    [SerializeField] Button buttonIconRoll;
    [SerializeField] Button buttonIconBack;
    [SerializeField] Button buttonIconInfo;
    [SerializeField] Image dialogue;
    [SerializeField] Sprite[] iconRoll;
    [SerializeField] Sprite[] iconBack;
    [SerializeField] Sprite[] iconInfo;
    [SerializeField] Sprite[] dialogueSprite;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        theme = PlayerPrefs.GetInt("Theme");
        themeDice = PlayerPrefs.GetInt("ThemeDice");

        Debug.Log($"Theme: {theme}, ThemeDice: {themeDice}");

        // Configura el fondo según el tema
        if (theme >= 0 && theme < img.Length)
        {
            background.GetComponent<Renderer>().material = img[theme];
        }
        else
        {
            background.GetComponent<Renderer>().material = img[0];
        }

        FindAllDice();
        SetDiceMaterials(themeDice);
        Colour(theme);
    }

    private void Colour(int theme)
    {

        if (theme == 0)
        {
            buttonIconRoll.image.sprite = iconRoll[1];
            buttonIconBack.image.sprite = iconBack[1];
            buttonIconInfo.image.sprite = iconInfo[1];
            dialogue.sprite = dialogueSprite[1];
            text.color = Color.black;

        }
        else if (theme == 1 || theme == 3 || theme == 4 || theme == 2)
        {
            buttonIconRoll.image.sprite = iconRoll[0];
            buttonIconBack.image.sprite = iconBack[0];
            buttonIconInfo.image.sprite = iconInfo[0];
            dialogue.sprite = dialogueSprite[0];
            text.color = Color.white;
        }
    }

    private void SetDiceMaterials(int themeIndex)
    {
        //if (themeIndex < 0 || themeIndex >= matD4.Length) themeIndex = 0;

        SetMaterialForDice(diceD4, matD4[themeIndex]);
        SetMaterialForDice(diceD6, matD6[themeIndex]);
        SetMaterialForDice(diceD8, matD8[themeIndex]);
        SetMaterialForDice(diceD10, matD10[themeIndex]);
        SetMaterialForDice(diceD12, matD12[themeIndex]);
        SetMaterialForDice(diceD20, matD20[themeIndex]);
    }

    private void SetMaterialForDice(List<GameObject> diceList, Material material)
    {
        foreach (var dice in diceList)
        {
            dice.GetComponent<Renderer>().material = material;
        }
    }

    public void FindAllDice()
    {
        diceD4.Clear();
        diceD6.Clear();
        diceD8.Clear();
        diceD10.Clear();
        diceD12.Clear();
        diceD20.Clear();

        // Buscar objetos con el script DiceType
        var allDice = FindObjectsOfType<DiceType>();

        // Filtrar por tipo y agregarlos a sus respectivas listas
        foreach (var dice in allDice)
        {
            switch (dice.GetDiceType())
            {
                case DiceType.Type.D4:
                    diceD4.Add(dice.gameObject);
                    break;
                case DiceType.Type.D6:
                    diceD6.Add(dice.gameObject);
                    break;
                case DiceType.Type.D8:
                    diceD8.Add(dice.gameObject);
                    break;
                case DiceType.Type.D10:
                    diceD10.Add(dice.gameObject);
                    break;
                case DiceType.Type.D12:
                    diceD12.Add(dice.gameObject);
                    break;
                case DiceType.Type.D20:
                    diceD20.Add(dice.gameObject);
                    break;
            }
        }

        Debug.Log($"D4: {diceD4.Count}, D6: {diceD6.Count}, D8: {diceD8.Count}, D10: {diceD10.Count}, D12: {diceD12.Count}, D20: {diceD20.Count}");
    }

    //public int GetTheme() { return theme; }
    //public int GetThemeDice() { return themeDice; }
}


