using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public Text balanceText;
    void Update()
    {
        balanceText.text = "Баланс: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Очки: " + score;
    }
}