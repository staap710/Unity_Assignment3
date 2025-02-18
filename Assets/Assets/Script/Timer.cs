using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }  

    public TMP_Text timerText;
    public float stopTime = 30f;
    public float elapsedTime { get; private set; }
    private bool isRunning = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();

            if (elapsedTime >= stopTime)
            {
                isRunning = false;
                Debug.Log("Timer Stopped!");
            }
            
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = elapsedTime.ToString("F2");
    }

    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("Timer Stopped!");
    }
}
