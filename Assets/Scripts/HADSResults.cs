using Assets.Scripts;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HADSResults : MonoBehaviour
{
    public TMP_Text HADSResultsText;

    public void LoadHADSResultsFromLocalStorage()
    {
        string existingResults = PlayerPrefs.GetString("HADSResults");
        Debug.Log(existingResults);

        if (string.IsNullOrEmpty(existingResults))
        {
            return;
        }

        HADSResultsWrapper wrapper = JsonUtility.FromJson<HADSResultsWrapper>(existingResults);

        string resultsString = FormatHADSResults(wrapper.Results);

        HADSResultsText.text = resultsString;
    }

    private string FormatHADSResults(List<HADSResult> results)
    {
        string formattedResults = "";

        foreach (var result in results)
        {
            formattedResults += $"{result.Date} - Тривога: {result.AnxietyScore}, Депресія: {result.DepressionScore}\n";
        }

        return formattedResults;
    }
}
