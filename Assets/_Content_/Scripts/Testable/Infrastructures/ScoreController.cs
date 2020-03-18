using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour, IScoreController
{
    public int Score { get; private set; }

    private int lastScore;
    private Text textComponent;

    public ScoreController()
    {
        this.Score = 0;
        this.lastScore = 0;
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
        if (this.lastScore != this.Score)
        {
            this.lastScore = this.Score;
            UpdateScoreOnTextComponent();
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

    public void UpdateScoreOnTextComponent()
    {
        this.textComponent.text = this.Score.ToString();
    }
}
