using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelGoalManager : MonoBehaviour
{
    public int itemsNeeded = 10;
    public float timeLimit = 120f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI deliveryText;

    private int itemsDelivered = 0;
    private float timer;

    void Start()
    {
        timer = timeLimit;
        UpdateUI();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
            timer = 0;

        UpdateUI();

        if (timer == 0)
        {
            Debug.Log("Time ran out!");
        }
    }

    public void ItemDelivered()
    {
        itemsDelivered++;

        UpdateUI();

        if (itemsDelivered >= itemsNeeded && timer > 0)
        {
            LoadNextLevel();
        }
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = "Time: " + minutes + ":" + seconds.ToString("00");
        deliveryText.text = "Delivered: " + itemsDelivered + "/" + itemsNeeded;
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}