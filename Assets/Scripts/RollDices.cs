using Unity.VisualScripting;
using UnityEngine;

public class RollDices : MonoBehaviour
{
    private string selectedOption;

    private GameObject[] dices;
    Rigidbody rb;
    Vector3 vectorTorque;
    int x, y, z;


    public bool hasRolled;


    void Start()
    {
        selectedOption = PlayerPrefs.GetString("selectedOption");
        Debug.Log("Selected Option: " + selectedOption);

        dices = GameObject.FindGameObjectsWithTag("Dice");
        x = RandomVector();
        y = RandomVector();
        z = RandomVector();
        vectorTorque = new Vector3(x, y, z);

        //if (selectedOption == "Tap Roll") TapRoll();
        if (selectedOption == "Auto Roll") AutoRoll();
        if (selectedOption == "Shake Roll") ShakeRoll();
    }

    private void Update()
    {
        if (selectedOption == "Tap Roll" && Input.GetMouseButtonDown(0))
        {
            TapRoll();
        }
    }


    void TapRoll()
    {
        Roll();
        
        // Roll the dices when the user taps the screen
        
    }
    void AutoRoll()
    {
        // Roll the dices automatically
        Roll();
    }
    void ShakeRoll()
    {
        // Roll the dices when the user shakes the device
    }

    public void Roll()
    {
        int resultRandomForce = RandomForce();
        int resultRandomNumberofAxis = RandomNumberOfAxis();

        /*if (resultRandomNumberofAxis >= 1 && resultRandomNumberofAxis <= 100) //0.6% chances 100
        {
            int resultValue = Random1Axis();
            if (resultValue == 1)
            {
                vectorTorque = new Vector3(x, 0, z);
            }
            else if (resultValue == 2)
            {
                vectorTorque = new Vector3(x, y, 0);
            }
            else if (resultValue == 3)
            {
                vectorTorque = new Vector3(0, y, z);
            }
        }
        else if (resultRandomNumberofAxis >= 100 && resultRandomNumberofAxis <= 1000) //90% chances 1000
        {
            vectorTorque = new Vector3(x, y, z);
        }*/


        foreach (GameObject dice in dices)
        {
            rb = dice.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * resultRandomForce, ForceMode.Impulse);
            rb.AddTorque(vectorTorque * resultRandomForce, ForceMode.Impulse);

        }
    }

    int Random1Axis()
    {
        int randomnumber;
        randomnumber = Random.Range(1, 4);
        return randomnumber;
    }
    int RandomNumberOfAxis()
    {
        int randomnumber;
        randomnumber = Random.Range(1, 1001);
        return randomnumber;
    }
    int RandomForce()
    {
        int randomnumber;
        randomnumber = Random.Range(3, 10);
        return randomnumber;
    }
    int RandomVector()
    {
        int randomnumber;
        randomnumber = Random.Range(-1, 2);
        return randomnumber;
    }
}
