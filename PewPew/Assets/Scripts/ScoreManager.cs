public class ScoreManager
{
    private static ScoreManager _instance;
    private int _score;

    public int Score => _score;

    public void Reinit()
    {
        _score = 0;
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public ScoreManager()
    {
        Reinit();
    }
    
    public static ScoreManager GetInstance()
    {
        if (_instance is null)
        {
            _instance = new ScoreManager();
        }

        return _instance;
    }

}