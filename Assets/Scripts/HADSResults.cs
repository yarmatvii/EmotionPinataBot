using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HADSResults : MonoBehaviour
{
    public TMP_Text HADSResultsText;

    public void LoadHADSResultsFromLocalStorage()
    {
        try
        {
            // 1. Load JSON string from PlayerPrefs
            string json = PlayerPrefs.GetString("HADSResults"); // "HADSResults" is the key
            Debug.Log(json);

            // 2. If no data is found, return an empty list
            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            // 3. Deserialize the JSON string back into a List<HADSResult>
            List<HADSResult> results = JsonUtility.FromJson<List<HADSResult>>(json);

            // Format results for display
            string resultsString = FormatHADSResults(results);

            // Display results in the Text GameObject
            HADSResultsText.text = resultsString;
            Debug.Log("HADS results loaded successfully!");
        }
        catch (Exception ex)
        {
            Debug.LogError("Error loading HADS results: " + ex.Message);
        }
    }

    private string FormatHADSResults(List<HADSResult> results)
    {
        string formattedResults = "";

        foreach (var result in results)
        {
            formattedResults += $"{result.Date.ToShortDateString()} - Тривога: {result.AnxietyScore}, Депресія: {result.DepressionScore}\n";
        }

        return formattedResults;
    }
}
