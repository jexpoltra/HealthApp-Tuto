using UnityEngine;

public class PressureDistributionTutorial : MonoBehaviour
{
    public GameObject overlay; // Das Tutorial-Overlay
    public GameObject[] panels; // Array f�r alle Tutorial-Panels

    private int currentPanelIndex = 0; // Aktueller Index im Panels-Array

    void Start()
    {
        // Initialisiere das Tutorial
        StartTutorial();
    }

    void StartTutorial()
    {
        // Setze das erste Panel aktiv und alle anderen inaktiv
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == 0); // Nur das erste Panel aktivieren
        }

        currentPanelIndex = 0; // Setze den aktuellen Schritt zur�ck
        overlay.SetActive(true);
    }

    public void NextStep()
    {
        if (currentPanelIndex < panels.Length - 1)
        {
            panels[currentPanelIndex].SetActive(false); // Verberge aktuelles Panel
            currentPanelIndex++; // N�chstes Panel
            panels[currentPanelIndex].SetActive(true); // Zeige n�chstes Panel
        }
        else
        {
            overlay.SetActive(false); // Verberge Overlay, wenn das Tutorial beendet ist
            Debug.Log("Tutorial abgeschlossen!");
        }
    }
}
