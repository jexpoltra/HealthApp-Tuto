using UnityEngine;

public class TutorialPanelManager : MonoBehaviour
{
    public GameObject[] Tutorials; // Array mit den Tutorial-Objekten
    public GameObject[] Panels;    // Array mit den dazugehörigen Panels

    void Update()
    {
        // Überprüfe, welches Tutorial aktiv ist
        for (int i = 0; i < Tutorials.Length; i++)
        {
            if (Tutorials[i].activeSelf) // Falls das Tutorial aktiviert ist
            {
                ActivatePanel(i);
                break; // Sobald ein aktives Tutorial gefunden wurde, breche die Schleife ab
            }
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
