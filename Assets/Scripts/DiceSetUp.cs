using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceSetUp : MonoBehaviour
{
    // Prepares the dices selected and the amount of them in the menu

    [SerializeField] private TextMeshProUGUI d4_number, d6_number, d8_number, d10_number, d12_number, d20_number;
    [SerializeField] private Button buttonPlusD4, buttonMinusD4, buttonPlusD6, buttonMinusD6, buttonPlusD8, buttonMinusD8, buttonPlusD10, buttonMinusD10, buttonPlusD12, buttonMinusD12, buttonPlusD20, buttonMinusD20;
    private int d4, d6, d8, d10, d12, d20 = 0;

    private bool isLimitReached= false;


    void Start()
    {
        
    }

    void Update()
    {
    }

    void LimitNumbers()
    {
        if (d4 >= 5 || d6 >= 5 || d8 >= 5 || d10 >= 5 || d12 >= 5 || d20 >= 5)
        {

        }

    }

    void CheckNumbers()
    {
        d4_number.text = d4.ToString();
        d6_number.text = d6.ToString();
        d8_number.text = d8.ToString();
        d10_number.text = d10.ToString();
        d12_number.text = d12.ToString();
        d20_number.text = d20.ToString();
    }


    //direfernciar que boton va a que numero
    public void Add() 
    {
        LimitNumbers();
        if (isLimitReached) return;

        CheckNumbers();
    }
    public void Remove() 
    {
        LimitNumbers();
        if (isLimitReached) return;
        CheckNumbers();
    }
    
}
