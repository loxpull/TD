using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public int score = 0;

    public Text scoreText;
    public Text balanceText;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        if (balanceText != null)
        {
            balanceText.text = "Баланс: " + score;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Очки: " + score;
        }

        if (balanceText != null)
        {
            balanceText.text = "Баланс: " + score;
        }
    }
}