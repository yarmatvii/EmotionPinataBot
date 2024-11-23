using System;

[Serializable]
public class TestResult
{
    public DateTime Date;

    public TestResult(DateTime date)
    {
        this.Date = date;
    }
}
