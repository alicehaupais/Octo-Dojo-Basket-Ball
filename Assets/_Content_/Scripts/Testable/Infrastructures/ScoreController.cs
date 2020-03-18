using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour, IScoreController
{
    public int Score { get; private set; }

    private int LastScore { get; set; }
    private Text textComponent;

    public ScoreController()
    {
        this.Score = 0;
        this.LastScore = 0;
    }

    public void Awake()
    {
        this.textComponent = GetComponent<Text>();
    }

    public void Start()
    {
        this.textComponent.text = this.Score.ToString();
    }

    public void Update()
    {
        if (this.LastScore != this.Score)
        {
            this.LastScore = this.Score;
            UpdateScoreFromTextComponent();
        }
    }

    public void AddScore(int score)
    {
        this.Score += score;

        if (this.Score < 0)
            this.Score = 0;
    }

    public string GetScoreFromTextComponent()
    {
        return this.textComponent.text;
    }

    public void UpdateScoreFromTextComponent()
    {
        this.textComponent.text = this.Score.ToString();
    }
}
