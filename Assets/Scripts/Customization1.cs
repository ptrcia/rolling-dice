using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

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

    //[SerializeField] GameObject[] diceD4;
    //[SerializeField] GameObject[] diceD6;
    //[SerializeField] GameObject[] diceD8;
   // [SerializeField] GameObject[] diceD10;
    //[SerializeField] GameObject[] diceD12;
   // [SerializeField] GameObject[] diceD20;
    int themeDice;


    List <GameObject> diceD4 = new List<GameObject>();
    List<GameObject> diceD6 = new List<GameObject>();
    List<GameObject> diceD8 = new List<GameObject>();
    List<GameObject> diceD10 = new List<GameObject>();
    List<GameObject> diceD12 = new List<GameObject>();
    List<GameObject> diceD20 = new List<GameObject>();

    private int currentThemeIndexDice = 0;


    [Header("Icons")]
    [SerializeField] Button buttonIconRoll;
    [SerializeField] Button buttonIconBack;
    [SerializeField] Button buttonIconInfo;


    private void Start()
    {
        theme = PlayerPrefs.GetInt("Theme");
        themeDice = PlayerPrefs.GetInt("ThemeDice");

        switch (theme)
        {
            case 0:
                background.GetComponent<Renderer>().material = img[0];
                break;
            case 1:
                background.GetComponent<Renderer>().material = img[1];
                break;
            case 2:
                background.GetComponent<Renderer>().material = img[2];
                break;
            case 3:
                background.GetComponent<Renderer>().material = img[3];
                break;
            case 4:
                background.GetComponent<Renderer>().material = img[4];
                break;
            case 5:
                background.GetComponent<Renderer>().material = img[5];
                break;
            default:
                background.GetComponent<Renderer>().material = img[0];
                break;
        }

        //diceD4[0]..material = matD4[themeDice]; //como lo encuentro
        //diceD4.AddRange(GameObject.FindGameObjectsWithTag("D4"));
        //diceD6.AddRange(GameObject.Find("Dice_d4(Clone)");


        switch (themeDice)
        {
            case 0:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[0];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[0];
                }
                for (int i = 0; i < diceD8.Count; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[0];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[0];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[0];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[0];
                }
                break;
            case 1:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[1];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[1];
                }
                for (int i = 0; i < diceD8.Count    ; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[1];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[1];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[1];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[1];
                }
                break;
            case 2:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[2];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[2];
                }
                for (int i = 0; i < diceD8.Count; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[2];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[2];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[2];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[2];
                }
                break;
            case 3:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[3];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[3];
                }
                for (int i = 0; i < diceD8.Count; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[3];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[3];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[3];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[3];
                }
                break;
            case 4:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[4];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[4];
                }
                for (int i = 0; i < diceD8.Count; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[4];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[4];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[4];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[4];
                }
                break;
            case 5:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[5];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[5];
                }
                for (int i = 0; i < diceD8.Count; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[5];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[5];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[5];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[5];
                }
                break;
            default:
                for (int i = 0; i < diceD4.Count; i++)
                {
                    diceD4[i].GetComponent<Renderer>().material = matD4[0];
                }
                for (int i = 0; i < diceD6.Count; i++)
                {
                    diceD6[i].GetComponent<Renderer>().material = matD6[0];
                }
                for (int i = 0; i < diceD8.Count; i++)
                {
                    diceD8[i].GetComponent<Renderer>().material = matD8[0];
                }
                for (int i = 0; i < diceD10.Count; i++)
                {
                    diceD10[i].GetComponent<Renderer>().material = matD10[0];
                }
                for (int i = 0; i < diceD12.Count; i++)
                {
                    diceD12[i].GetComponent<Renderer>().material = matD12[0];
                }
                for (int i = 0; i < diceD20.Count; i++)
                {
                    diceD20[i].GetComponent<Renderer>().material = matD20[0];
                }
                break;
            }
        }


}
