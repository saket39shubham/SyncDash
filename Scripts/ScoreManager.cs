using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;

    private float timer;

    void Awake()
    {
        Instance = this;
        score = 0; // ensure starts from 0
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            score += 10;
            timer = 0f;
        }
    }

    public void AddPoints(int value)
    {
        score += value;
    }
}