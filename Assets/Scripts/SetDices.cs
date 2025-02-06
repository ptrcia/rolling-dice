using UnityEngine;

public class SetDices : MonoBehaviour
{

    private int d4, d6, d8, d10, d12, d20;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject d4Prefab;
    [SerializeField] private GameObject d6Prefab;
    [SerializeField] private GameObject d8Prefab;
    [SerializeField] private GameObject d10Prefab;
    [SerializeField] private GameObject d12Prefab;
    [SerializeField] private GameObject d20Prefab;


    private void Start()
    {
        d4 = PlayerPrefs.GetInt("d4");
        d6 = PlayerPrefs.GetInt("d6");
        d8 = PlayerPrefs.GetInt("d8");
        d10 = PlayerPrefs.GetInt("d10");
        d12 = PlayerPrefs.GetInt("d12");
        d20 = PlayerPrefs.GetInt("d20");


        Spawn(d4, d6, d8, d10, d12, d20);
    }

    private void Spawn(int d4, int d6, int d8, int d10, int d12, int d20)
    {
        Debug.Log("Spawning: D4(" + d4 + ") D6(" + d6 + ") D8(" + d8 + ") D10(" + d10 + ") D12(" + d12 + ") D20(" + d20 + ")");
        int spawnIndex = 0;

        for (int i = 0; i < d4; i++)
        {
            Instantiate(d4Prefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
        for (int i = 0; i < d6; i++)
        {
            Instantiate(d6Prefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
        for (int i = 0; i < d8; i++)
        {
            Instantiate(d8Prefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
        for (int i = 0; i < d10; i++)
        {
            Instantiate(d10Prefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
        for (int i = 0; i < d12; i++)
        {
            Instantiate(d12Prefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
        for (int i = 0; i < d20; i++)
        {
            Instantiate(d20Prefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
        }
    }
}
