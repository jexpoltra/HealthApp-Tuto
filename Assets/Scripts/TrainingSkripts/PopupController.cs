using UnityEngine;

public class ExercisePopupController : MonoBehaviour
{
    public GameObject PopupPanel; // Referenz zum Popup-Panel

    // Methode, um das Popup zu �ffnen
    public void ShowPopup()
    {
        PopupPanel.SetActive(true); // Popup anzeigen
    }

    // Methode, um das Popup zu schlie�en
    public void ClosePopup()
    {
        PopupPanel.SetActive(false); // Popup ausblenden
    }
}
