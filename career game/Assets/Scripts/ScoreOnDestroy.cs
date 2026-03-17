using UnityEngine;

public class DestroyScore : MonoBehaviour
{
    private void OnDestroy()
    {
        if (gameObject.CompareTag("Cart"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore();
            }
        }
    }
}