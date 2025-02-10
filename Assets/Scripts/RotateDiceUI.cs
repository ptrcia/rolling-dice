using UnityEngine;

public class RotateDiceUI : MonoBehaviour
{
    [SerializeField] int Speed;
    [SerializeField] Vector3 Rotation;

    private void Start()
    {
        Speed = 5;
        Rotation = new Vector3(RandomVector(), RandomVector(),  RandomVector());    
    }
    void Update()
    {
        transform.Rotate(Rotation * Speed * Time.deltaTime);
    }

    float RandomVector()
    {
        return Random.Range(-2, 2);
    }
}
