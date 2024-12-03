using System;

[Serializable]
public class HADSResult : TestResult
{
    public int AnxietyScore;
    public int DepressionScore;

    public HADSResult(DateTime date, int anxietyScore, int depressionScore) : base(date)
    {
        this.AnxietyScore = anxietyScore;
        this.DepressionScore = depressionScore;
    }
}
