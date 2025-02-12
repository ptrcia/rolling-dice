using System;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    #region Instanciate
    private static Accelerometer instance;

    public static Accelerometer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Accelerometer>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned Accelerometer", typeof(Accelerometer)).GetComponent<Accelerometer>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Shake Detection")]
    public Action OnShake;
    [SerializeField] private float shakeDetectionThreshold = 2.0f;
    private float accelerometerUpdateInterval = 1.0f / 60.0f;
    private float lowPassKernelWidthInSeconds = 1.0f;
    private float lowPassFilterFactor;
    private Vector3 lowPassValue;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        // Shake detected
        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            OnShake?.Invoke();
        }
    }
}
