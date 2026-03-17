using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    [Header("Timer")]
    public float timeRemaining = 60f;
    public TMP_Text timerText;
    public bool timerIsRunning = true;

    void Awake()
    {
        instance = this;   // 🔥 THIS WAS MISSING
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (timerIsRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }

            UpdateUI();
        }
    }

    public void AddScore()
    {
        score += 100;
        UpdateUI();
        Debug.Log("Score Added!");
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining);
    }
}