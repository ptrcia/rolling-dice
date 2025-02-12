using UnityEngine;


public class DiceType : MonoBehaviour
{
    public enum Type { D4, D6, D8, D10, D12, D20 } 

    [SerializeField] private Type diceType;

    public Type GetDiceType()
    {
        return diceType; 
    }
}
