using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell! You Lose.");
            LoseGame();
        }

        if (other.CompareTag("Boss"))
        {
            Debug.Log("Boss fell! You Win.");
            WinGame();
        }
    }

    void WinGame()
    {
        // Load win scene or trigger win UI
        SceneManager.LoadScene("WinScene");
    }

    void LoseGame()
    {
        // Reload level or load lose scene
        SceneManager.LoadScene("LoseScene");
    }
}