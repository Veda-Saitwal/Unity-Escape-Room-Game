using UnityEngine;
using TMPro; // if you’re using TextMeshPro

public class SimpleTimer : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 minutes
    public bool timerRunning = true;
    public TextMeshPro textDisplay; // drag your TimerText here
    public Renderer cubeRenderer;   // drag TimerCube renderer

    void Start()
    {
        if (cubeRenderer == null) cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!timerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0) timeRemaining = 0;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            if (textDisplay != null)
                textDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerRunning = false;
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("You lost, click play again!");
        if (cubeRenderer != null)
            cubeRenderer.material.color = Color.red; // cube turns red when time ends
        if (textDisplay != null)
            textDisplay.text = "YOU LOST!";
    }
}
