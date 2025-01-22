// Test-Kommentar hinzugefügt


using UnityEngine;

public class TutorialPanelManager : MonoBehaviour
{
    public GameObject[] Tutorials; // Array mit den Tutorial-Objekten
    public GameObject[] Panels;    // Array mit den dazugeh�rigen Panels

    void Update()
    {
        // �berpr�fe, welches Tutorial aktiv ist
        for (int i = 0; i < Tutorials.Length; i++)
        {
            if (Tutorials[i].activeSelf) // Falls das Tutorial aktiviert ist
            {
                ActivatePanel(i);
                break; // Sobald ein aktives Tutorial gefunden wurde, breche die Schleife ab
            }
        }
    }
public void SwitchToNextPage(int currentIndex)
{
    // Deaktiviere die aktuelle Seite
    if (currentIndex >= 0 && currentIndex < Panels.Length)
    {
        Panels[currentIndex].SetActive(false); // Aktuelles Panel deaktivieren
    }

    // Aktiviere die nächste Seite
    int nextIndex = currentIndex + 1;
    if (nextIndex < Panels.Length)
    {
        Panels[nextIndex].SetActive(true); // Nächstes Panel aktivieren
    }
    else
    {
        Debug.LogWarning("Es gibt keine weitere Seite."); // Optional: Warnung, wenn keine weitere Seite vorhanden ist
    }
}

    private void ActivatePanel(int index)
    {
        // Deaktiviere alle Panels
        for (int i = 0; i < Panels.Length; i++)
        {
            Panels[i].SetActive(i == index); // Aktiviere nur das Panel, das dem aktiven Tutorial entspricht
        }
    }
}
