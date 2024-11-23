using UnityEngine;

public class NavigarionScript : MonoBehaviour
{
    public GameObject panelToActivate;
    public GameObject panelToDeactivate;

    public void SwitchPanels()
    {
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
        if (panelToDeactivate != null)
        {
            panelToDeactivate.SetActive(false);
        }
    }
}
