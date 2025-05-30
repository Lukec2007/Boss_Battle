using UnityEngine;

public class TogglePanelUI : MonoBehaviour
{
    public GameObject panel;  // Assign the panel to show/hide

    public void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}

