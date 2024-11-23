using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HADSScoring : MonoBehaviour
{
    public ToggleGroup[] AnxietyToggleGroups;  // Anxiety questions (1, 3, 5, 7, 9, 11, 13)
    public ToggleGroup[] DepressionToggleGroups; // Depression questions (2, 4, 6, 8, 10, 12, 14)
    public TestManager TestManager;
    public GameObject HadsPanel;

    public void GetResults()
    {
        int anxietyScore = CalculateScore(AnxietyToggleGroups);
        int depressionScore = CalculateScore(DepressionToggleGroups);

        string GetStatus(int score)
        {
            if (score <= 7) return "Норма";
            if (score <= 10) return "Виражена";

            return "Клінічно виражена";
        }

        string anxietyStatus = GetStatus(anxietyScore) + (anxietyScore > 7 ? " тривога" : "");
        string depressionStatus = GetStatus(depressionScore) + (depressionScore > 7 ? " депресія" : "");

        string results = $"Тривожність:\n {anxietyStatus}\nДепресія:\n {depressionStatus}";

        TestManager.currentTestPanel = HadsPanel; // Set the HADS panel as current
        SaveHADSResult(anxietyScore, depressionScore);
        TestManager.ShowResults(results);

        Selectable[] selectables = HadsPanel.GetComponentsInChildren<Selectable>();

        foreach (Selectable selectable in selectables)
        {
            selectable.interactable = false;
        }
    }

    private int CalculateScore(ToggleGroup[] toggleGroups)
    {
        int score = 0;

        foreach (var group in toggleGroups)
        {
            Toggle activeToggle = group.ActiveToggles().FirstOrDefault();

            if (activeToggle != null)
            {
                score += activeToggle.GetComponent<ToggleValue>().Value;
            }
        }

        return score;
    }

    private void SaveHADSResult(int anxietyScore, int depressionScore)
    {
        try
        {
            HADSResult testResult = new HADSResult(DateTime.Now, 8, 9);
            string json1 = JsonUtility.ToJson(testResult);
            Debug.Log(json1);

            // Load existing HADS results
            List<HADSResult> results = new()
            {
                new HADSResult(DateTime.Now, anxietyScore, depressionScore)
            };

            Debug.Log(results.ToString() + DateTime.Now + anxietyScore.ToString() + depressionScore.ToString());

            string json = JsonUtility.ToJson(results);
            Debug.Log(json);

            // 2. Save the JSON string to PlayerPrefs with the key "HADSResults"
            PlayerPrefs.SetString("HADSResults", json);
            PlayerPrefs.Save();
            Debug.Log("HADS results saved successfully!");
        }
        catch (Exception ex)
        {
            Debug.LogError("Error saving HADS results: " + ex.Message);
        }
    }
}

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
