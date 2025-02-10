using TMPro;
using UnityEngine;

public class NoSimulatedRoll : MonoBehaviour
{

    [SerializeField] SetDices setDices;
    private int d4, d6, d8, d10, d12, d20;
    private int d4Random, d6Random, d8Random, d10Random, d12Random, d20Random;
    private int d44Result, d6Result, d8Result, d10Result, d12Result, d20Result;
    private int result;

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

    public void CalculateResults()        // Simulate the roll of the dices
    {
        d4Random = Random.Range(1, 5);
        d6Random = Random.Range(1, 7);
        d8Random = Random.Range(1, 9);
        d10Random = Random.Range(1, 11);
        d12Random = Random.Range(1, 13);
        d20Random = Random.Range(1, 21);

        Debug.Log("Results: D4(" + d4Random + ") D6(" + d6Random + ") D8(" + d8Random + ") D10(" + d10Random + ") D12(" + d12Random + ") D20(" + d20Random + ")");

        d44Result = d4 * d4Random;
        d6Result = d6 * d6Random;
        d8Result = d8 * d8Random;
        d10Result = d10 * d10Random;
        d12Result = d12 * d12Random;
        d20Result = d20 * d20Random;
        
        result = d44Result + d6Result + d8Result + d10Result + d12Result + d20Result;

        resultText.text = "Result: " + result;
        d4Text.text = "D4: " + d4;
        d6Text.text = "D6: " + d6;
        d8Text.text = "D8: " + d8;
        d10Text.text = "D10: " + d10;
        d12Text.text = "D12: " + d12;
        d20Text.text = "D20: " + d20;
        d4ResultText.text = "D4 Result: " + d4Random;
        d6ResultText.text = "D6 Result: " + d6Random;
        d8ResultText.text = "D8 Result: " + d8Random;
        d10ResultText.text = "D10 Result: " + d10Random;
        d12ResultText.text = "D12 Result: " + d12Random;
        d20ResultText.text = "D20 Result: " + d20Random;
    }

}
