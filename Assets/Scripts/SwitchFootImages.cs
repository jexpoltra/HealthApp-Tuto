using UnityEngine;
using UnityEngine.UI;

public class SwitchFootImages : MonoBehaviour
{
    public GameObject ImageLeft;  // Linkes Bild
    public GameObject ImageRight; // Rechtes Bild

    public void ShowLeftImage()
    {
        ImageLeft.SetActive(true);   // Linkes Bild aktivieren
        ImageRight.SetActive(false); // Rechtes Bild deaktivieren
    }

    public void ShowRightImage()
    {
        ImageLeft.SetActive(false); // Linkes Bild deaktivieren
        ImageRight.SetActive(true);  // Rechtes Bild aktivieren
    }
}

