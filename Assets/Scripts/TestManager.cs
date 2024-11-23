using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public GameObject resultsPopup;
    public TMP_Text popupResultText;
    public Button backButton;
    public GameObject allTestsPanel;

    // Add a public variable to store the current test panel
    public GameObject currentTestPanel;

    void Start()
    {
        backButton.onClick.AddListener(GoToAllTestsPanel);
    }

    public void ShowResults(string results)
    {
        popupResultText.text = results;
        resultsPopup.SetActive(true);
    }

    public void GoToAllTestsPanel()
    {
        resultsPopup.SetActive(false);
        allTestsPanel.SetActive(true);

        if (currentTestPanel != null)
        {
            currentTestPanel.SetActive(false);

            // Re-enable all Selectable components within the previously active panel
            Selectable[] selectables = currentTestPanel.GetComponentsInChildren<Selectable>();
            foreach (Selectable selectable in selectables)
            {
                selectable.interactable = true;
            }
        }
    }
}
