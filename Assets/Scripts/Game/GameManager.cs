using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int playerScore = 0;
    private bool gameOver = false;

    void Awake()
    {
        // Ensure only one GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        if (!gameOver)
        {
            playerScore += points;
            Debug.Log("Score: " + playerScore);
        }
    }

    public void EndGame()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}