using System.Collections.Generic;
using UnityEngine;

public class RollDices : MonoBehaviour
{
    private int autoRoll;
    private int shakeRoll;

    private GameObject[] dices;
    Rigidbody rb;
    Vector3 vectorTorque;

    float isSimulatedValue;

    [SerializeField] SelectDice selectDice;
    [SerializeField] NoSimulatedRoll noSimulatedRoll;

    List<GameObject> selectedDices = new List<GameObject>();
    List<GameObject> unSelectedDices = new List<GameObject>();

    void Start()
    {
        isSimulatedValue = PlayerPrefs.GetInt("isSimulated");
        autoRoll = PlayerPrefs.GetInt("isAuto");
        shakeRoll = PlayerPrefs.GetInt("isShake");

        dices = GameObject.FindGameObjectsWithTag("Dice");

        CheckIfSimulated();
    }

    void CheckIfSimulated()
    {
        if (isSimulatedValue == 0) //we have to calculate and show the result
        {
            noSimulatedRoll.CalculateResults();
        }
        else
        {
            if(autoRoll == 1) AutoRoll();
            if (shakeRoll == 1) ShakeRoll();
        }
    }

    public void ReRoll()
    {
        if (isSimulatedValue == 0) //we have to calculate and show the result
        {
            noSimulatedRoll.CalculateResults();
        }
        else
        {
            Roll();
        }
    }


    void AutoRoll()
    {
        // Roll the dices automatically
        Roll();
    }
    void ShakeRoll()
    {
        // Roll the dices when the user shakes the device
        Accelerometer.Instance.OnShake += ReRoll;
    }

    public void Roll()
    {
        selectedDices = selectDice.GetTargets();

        int resultRandomForce = RandomForce();
        int resultRandomNumberofAxis = RandomNumberOfAxis();
        vectorTorque = RandomVector();

        Debug.Log("Selected dices-> " + selectedDices.Count);
        if (selectedDices.Count > 0)  //if there are selected dices
        {
            foreach (GameObject dice in dices) //get the unselected dices and make them kinematic
            {
                if (!selectedDices.Contains(dice))
                {
                    unSelectedDices.Add(dice);
                    rb = dice.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }
                }
            }

            foreach (GameObject dice in selectedDices) //roll the selected dices and roll them
            {
                rb = dice.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
                    rb.AddTorque(RandomVector() * RandomForce(), ForceMode.Impulse);
                }
            }
        }
        else //if (selectedDices.Count == 0) //if there are no selected dices
        {
            foreach (GameObject dice in dices) //roll all dices
            {
                rb = dice.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(Vector3.up * resultRandomForce, ForceMode.Impulse);
                rb.AddTorque(vectorTorque * resultRandomForce, ForceMode.Impulse);
                /*if (rb != null)
                {
                    rb = dice.GetComponent<Rigidbody>();

                    rb.isKinematic = false;
                    //rb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
                    //rb.AddTorque(RandomVector() * RandomForce(), ForceMode.Impulse);
                    rb.AddForce(Vector3.up * resultRandomForce, ForceMode.Impulse);
                    rb.AddTorque(vectorTorque * resultRandomForce, ForceMode.Impulse);
                }*/

            }
        }

    }

    #region Random Values
    int RandomNumberOfAxis() {return Random.Range(1, 1001);}
    int RandomForce() {return Random.Range(5, 10);}
    Vector3 RandomVector()
    {
        Vector3 randomVector;
        do
        {
            randomVector = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        } while (randomVector == Vector3.zero);
        return randomVector;
    }
    #endregion
}
