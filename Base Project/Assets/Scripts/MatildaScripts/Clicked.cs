using UnityEngine;
using UnityEngine.UI;

public class HidePanelOnClick : MonoBehaviour
{
    public Button myButton; // Assign this in the Inspector
    public GameObject panel; // Assign the UI panel to hide

    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(HidePanel);
        }
    }

    void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
