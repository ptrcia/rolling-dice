using System.Text;
using TMPro;
using UnityEngine;

public class NoSimulatedRoll : MonoBehaviour
{

    [SerializeField] SetDices setDices;
    private int d4, d6, d8, d10, d12, d20;
    private int d4Random, d6Random, d8Random, d10Random, d12Random, d20Random;
    private int result;

    [SerializeField] GameObject panel1;
    [SerializeField] GameObject panel2;
    [SerializeField] GameObject resultPanel;

    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI d4Text;
    [SerializeField] TextMeshProUGUI d6Text;
    [SerializeField] TextMeshProUGUI d8Text;
    [SerializeField] TextMeshProUGUI d10Text;
    [SerializeField] TextMeshProUGUI d12Text;
    [SerializeField] TextMeshProUGUI d20Text;
    [SerializeField] TextMeshProUGUI d4ResultText;
    [SerializeField] TextMeshProUGUI d6ResultText;
    [SerializeField] TextMeshProUGUI d8ResultText;
    [SerializeField] TextMeshProUGUI d10ResultText;
    [SerializeField] TextMeshProUGUI d12ResultText;
    [SerializeField] TextMeshProUGUI d20ResultText;

    private void Start()
    {
        d4 = PlayerPrefs.GetInt("d4");
        d6 = PlayerPrefs.GetInt("d6");
        d8 = PlayerPrefs.GetInt("d8");
        d10 = PlayerPrefs.GetInt("d10");
        d12 = PlayerPrefs.GetInt("d12");
        d20 = PlayerPrefs.GetInt("d20");
    }

    public void CalculateResults()        // Calculate the roll of the dices
    {

        panel1.SetActive(true);
        panel2.SetActive(true);
        resultPanel.SetActive(true);

        d4Random = GenerateRandomResults(d4, 4, d4ResultText);
        d6Random = GenerateRandomResults(d6, 6, d6ResultText);
        d8Random = GenerateRandomResults(d8, 8, d8ResultText);
        d10Random = GenerateRandomResults(d10, 10, d10ResultText);
        d12Random = GenerateRandomResults(d12, 12, d12ResultText);
        d20Random = GenerateRandomResults(d20, 20, d20ResultText);


        Debug.Log("Results: D4(" + d4Random + ") D6(" + d6Random + ") D8(" + d8Random + ") D10(" + d10Random + ") D12(" + d12Random + ") D20(" + d20Random + ")");


        if (d4 == 0) { d4ResultText.text = ""; }
        if (d6 == 0) { d6ResultText.text = ""; }
        if (d8 == 0) { d8ResultText.text = ""; }
        if (d10 == 0) { d10ResultText.text = ""; }
        if (d12 == 0) { d12ResultText.text = ""; }
        if (d20 == 0) { d20ResultText.text = ""; }


        result = d4Random + d6Random + d8Random + d10Random + d12Random + d20Random;

        resultText.text = "Result: " + result;

        d4Text.text = "D4: " + d4;
        d6Text.text = "D6: " + d6;
        d8Text.text = "D8: " + d8;
        d10Text.text = "D10: " + d10;
        d12Text.text = "D12: " + d12;
        d20Text.text = "D20: " + d20;
    }
    #region Generate Random

    private int GenerateRandomResults(int number, int maxRange, TextMeshProUGUI resultText)
    {
        int total = 0;
        StringBuilder results = new StringBuilder();
        for (int i = 0; i < number; i++)
        {
            int roll = Random.Range(1, maxRange + 1);
            total += roll;
            results.Append( "  " + roll + "  ");
        }
        resultText.text = results.ToString() +" = "+ total;

        return total;
    }

    #endregion
}
