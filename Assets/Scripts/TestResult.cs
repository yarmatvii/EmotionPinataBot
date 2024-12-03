using System;

[Serializable]
public class TestResult
{
    public string Date;

    public TestResult(DateTime date)
    {
        this.Date = date.ToShortDateString();
    }
}
