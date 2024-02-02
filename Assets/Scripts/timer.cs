using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image Customer_Timer;
    float time_remaining;
    public float max_time = 5.0f;

    // Set this flag to true when the person is spawned
    private bool isPersonSpawned = false;

    void Start()
    {
        // Do not start the timer immediately in the Start method
        // time_remaining = max_time;
        // UpdateTimerUI(); // Update UI when the timer is reset
    }

    void Update()
    {
        if (isPersonSpawned)
        {
            if (time_remaining > 0)
            {
                time_remaining -= Time.deltaTime;
                Customer_Timer.fillAmount = time_remaining / max_time;
            }
            else
            {
                Debug.Log("Countdown completed!");
                // Optionally: Trigger an event or some action when the countdown completes
                ResetTimer(); // Reset the timer for the next person
            }
        }
    }

    public void StartTimer()
    {
        // Start the timer when called (e.g., when the person is spawned)
        time_remaining = max_time;
        isPersonSpawned = true;
        UpdateTimerUI(); // Update UI when the timer is reset
    }

    public void ResetTimer()
    {
        time_remaining = max_time;
        isPersonSpawned = false;
        UpdateTimerUI(); // Update UI when the timer is reset
    }

    void UpdateTimerUI()
    {
        // Additional UI updates can be added here (e.g., changing color based on progress)
        Debug.Log("Time Remaining: " + time_remaining);
        Debug.Log("Fill Amount: " + Customer_Timer.fillAmount);
    }
}