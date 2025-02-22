using UnityEngine;
using TMPro; // F�r TextMeshPro
using UnityEngine.UI; // F�r Buttons

public class PressureDistributionTutorial : MonoBehaviour
{
    public GameObject overlay; // Das Tutorial-Overlay
    public GameObject[] panels; // Array f�r alle Tutorial-Panels
    public TextMeshProUGUI instructionText; // Textfeld f�r die Anweisungen
    public Button pressureDistributionButton; // Der Pressure Distribution Button
    public Button Left; // Button f�r linken Fu�
    public Button right; // Button f�r rechten Fu�
    public GameObject pressureDistributionPage; // Die Seite, die angezeigt werden soll
    public Button nextStepButton; // Button f�r den n�chsten Schritt

    private int currentPanelIndex = 0; // Aktueller Index im Panels-Array
    private bool tutorialActive = true; // Gibt an, ob das Tutorial aktiv ist

    private Color originalColor; // Speichert die urspr�ngliche Farbe des Buttons
    private Color highlightColor = Color.yellow; // Farbe f�r den Highlight-Effekt

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
        instructionText.text = "Dr�cke auf �Pressure Distribution�, um fortzufahren.";
        HighlightButton(pressureDistributionButton);
        nextStepButton.gameObject.SetActive(false); // Verberge den Next-Button
    }

    void HighlightButton(Button button)
    {
        // Speichere die urspr�ngliche Farbe des Buttons
        originalColor = button.GetComponent<Image>().color;

        // �ndere die Farbe des Buttons, um ihn hervorzuheben
        button.GetComponent<Image>().color = highlightColor;

        // Aktiviere den Button nur, wenn das Tutorial aktiv ist
        button.onClick.AddListener(OnPressureDistributionButtonClick);
    }

    void ResetButtonColor(Button button)
    {
        // Setze die Farbe des Buttons auf die urspr�ngliche Farbe zur�ck
        button.GetComponent<Image>().color = originalColor;
    }

    void OnPressureDistributionButtonClick()
    {
        if (tutorialActive && currentPanelIndex == 0)
        {
            tutorialActive = false;
            panels[currentPanelIndex].SetActive(false); // Verberge das erste Panel
            pressureDistributionPage.SetActive(true); // Zeige die Seite
            ResetButtonColor(pressureDistributionButton); // Setze die Button-Farbe zur�ck
            StartTutorialSteps(); // Starte weitere Tutorial-Schritte
        }
    }

    void StartTutorialSteps()
    {
        tutorialActive = true;
        currentPanelIndex = 1; // Wechsel zu Schritt 1
        ShowStep(currentPanelIndex);
    }

    public void ShowStep(int step)
    {
        // Deaktiviere alle Panels au�er dem aktuellen
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == step);
        }

        // Je nach Schritt andere Elemente hervorheben
        if (step == 1)
        {
            instructionText.text = "W�hle zwischen dem linken und rechten Fu�, um Daten anzuzeigen.";
            HighlightButton(Left); // Highlight f�r linken Fu�
            HighlightButton(right); // Highlight f�r rechten Fu�
        }

        // Aktiviere den Next-Button, falls nicht am Ende des Tutorials
        if (step < panels.Length - 1)
        {
            nextStepButton.gameObject.SetActive(true);
        }
        else
        {
            nextStepButton.gameObject.SetActive(false);
            instructionText.text = "Das Tutorial ist abgeschlossen! Du kannst die App jetzt erkunden.";
        }
    }

    public void NextStep()
    {
        if (tutorialActive && currentPanelIndex < panels.Length - 1)
        {
            currentPanelIndex++;
            ShowStep(currentPanelIndex);
        }
    }
}