using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public GameObject appPages; // Container für alle Seiten
    private string currentPage;
    public GameObject backButton;
    public GameObject pageHome; // Referenz zur "pageHome"

    void Start()
    {
        // Überprüfe, ob die Startseite "pageHome" ist, und setze den BackButton entsprechend
        if (pageHome != null && pageHome.activeSelf)
        {
            backButton.SetActive(false); // BackButton deaktivieren, wenn auf pageHome gestartet wird
            currentPage = pageHome.name; // Setze die Startseite als aktuelle Seite
            Debug.Log("Starting on pageHome, backButton disabled.");
        }
        else
        {
            backButton.SetActive(true); // BackButton aktivieren, falls eine andere Seite aktiv ist
            Debug.Log("Starting on another page, backButton enabled.");
        }
    }

    void Update()
    {
        // Optional: Zusätzliche Logik hier
    }

    // Methode zum Öffnen einer Seite (nur für appPages verwendet)
    public void OpenAppPage(GameObject appPageToOpen)
    {
        if (appPageToOpen == null)
        {
            Debug.Log("No app page selected to open");
        }
        else
        {
            SetChildrenState(appPages, false);
            appPageToOpen.gameObject.SetActive(true);
            currentPage = appPageToOpen.name;
            Debug.Log($"Current Page Set to: {currentPage}");

            // Gleiche Logik wie im Start: BackButton ein- oder ausblenden
            if (appPageToOpen.name != "pageHome")
            {
                backButton.SetActive(true);
            }
            else
            {
                backButton.SetActive(false);
            }
        }
    }

    // Methode zum Umschalten eines bestimmten Dropdown-Menüs
    public void ToggleDropdownMenu(GameObject dropdownMenu)
    {
        if (dropdownMenu != null)
        {
            bool isActive = dropdownMenu.activeSelf;
            dropdownMenu.SetActive(!isActive); // Aktivieren/Deaktivieren des Dropdowns
        }
        else
        {
            Debug.LogWarning("Dropdown Menu not assigned!");
        }
    }

    // Methode zum Umschalten eines Bildes
    public void ToggleImage(GameObject imageObject)
    {
        if (imageObject != null)
        {
            bool isActive = imageObject.activeSelf;
            imageObject.SetActive(!isActive); // Aktivieren/Deaktivieren des Bildes
        }
        else
        {
            Debug.LogWarning("Image not assigned!");
        }
    }

    // Setzt den Zustand aller Kinder eines Objekts (optional für Seiten)
    public void SetChildrenState(GameObject parentObject, Boolean activate)
    {
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.SetActive(activate);
        }
    }
}
