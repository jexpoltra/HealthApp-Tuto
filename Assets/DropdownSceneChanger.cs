using UnityEngine;
using TMPro; // F�r TextMeshPro Dropdown

public class DropdownSceneChanger : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Verkn�pfe das Dropdown im Inspektor
    public GameObject pageHome; // Verkn�pfe das Home-Panel
    public GameObject pageKnowledge; // Verkn�pfe das Knowledge-Panel
    public GameObject pageTraining; // Verkn�pfe das Training-Panel
    public GameObject backButton;

    void Start()
    {
        // Registriere das Dropdown-Event
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Starte mit Home-Panel aktiv
        ShowHomePage();
    }

    void OnDropdownValueChanged(int value)
    {
        // Wechsel basierend auf der Auswahl
        switch (value)
        {
            case 0:
                ShowHomePage();
                break;
            case 1:
                ShowKnowledgePage();
                break;
            case 2:
                ShowTrainingPage();
                break;
            default:
                Debug.LogWarning("Ung�ltige Auswahl im Dropdown.");
                break;
        }
    }

    void ShowHomePage()
    {
        pageHome.SetActive(true);
        pageKnowledge.SetActive(false);
        pageTraining.SetActive(false);
    }

    void ShowKnowledgePage()
    {
        pageHome.SetActive(false);
        pageKnowledge.SetActive(true);
        pageTraining.SetActive(false);
        backButton.SetActive(true);
    }

    void ShowTrainingPage()
    {
        pageHome.SetActive(false);
        pageKnowledge.SetActive(false);
        pageTraining.SetActive(true);
        backButton.SetActive(true);
    }
}
