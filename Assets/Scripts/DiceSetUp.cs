using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceSetUp : MonoBehaviour
{
    // Prepares the dices selected and the amount of them in the menu

    [SerializeField] private TextMeshProUGUI d4_number, d6_number, d8_number, d10_number, d12_number, d20_number;
    private int d4 = 0, d6 = 0, d8 = 0, d10 = 0, d12 = 0, d20 = 0;

    [SerializeField] private int AddLimit = 5;
    private int RemoveLimit = 0;

    void CheckNumbers()
    {
        d4_number.text = d4.ToString();
        d6_number.text = d6.ToString();
        d8_number.text = d8.ToString();
        d10_number.text = d10.ToString();
        d12_number.text = d12.ToString();
        d20_number.text = d20.ToString();
    }

    public void Add() 
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (button.name == "Button+D4" && d4 < AddLimit)
        {
            d4++;
        }
        else if (button.name == "Button+D6" && d6 < AddLimit)
        {
            d6++;
        }
        else if (button.name == "Button+D8" && d8 < AddLimit)
        {
            d8++;
        }
        else if (button.name == "Button+D10" && d10 < AddLimit)
        {
            d10++;
        }
        else if (button.name == "Button+D12" && d12 < AddLimit)
        {
            d12++;
        }
        else if (button.name == "Button+D20" && d20 < AddLimit)
        {
            d20++;
        }

         CheckNumbers();
    }
    public void Remove() 
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (button.name == "Button-D4" && d4 > RemoveLimit)
        {
            d4--;
        }
        else if (button.name == "Button-D6" && d6 > RemoveLimit)
        {
            d6--;
        }
        else if (button.name == "Button-D8" && d8 > RemoveLimit)
        {
            d8--;
        }
        else if (button.name == "Button-D10" && d10 > RemoveLimit)
        {
            d10--;
        }
        else if (button.name == "Button-D12" && d12 > RemoveLimit)
        {
            d12--;
        }
        else if (button.name == "Button-D20" && d20 > RemoveLimit)
        {
            d20--;
        }

        CheckNumbers();
    }

    public int GetD4() { return d4; }
    public int GetD6() { return d6; }
    public int GetD8() { return d8; }
    public int GetD10() { return d10; }
    public int GetD12() { return d12; }
    public int GetD20() { return d20; }

}
