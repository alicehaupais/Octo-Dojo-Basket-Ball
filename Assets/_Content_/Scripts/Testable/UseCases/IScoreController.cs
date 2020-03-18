public interface IScoreController
{
    int Score { get; }

    void AddScore(int score);

    string GetScoreFromTextComponent();

    void UpdateScoreOnTextComponent();
}