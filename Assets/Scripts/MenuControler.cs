using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public GameObject appPages; // Container f�r alle Seiten
    private string currentPage;
    public GameObject pageHome; // Referenz zur "pageHome"

   

    void Update()
    {
        // Optional: Zus�tzliche Logik hier
    }

    // Methode zum �ffnen einer Seite (nur f�r appPages verwendet)
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

          
        }
    }

    // Methode zum Umschalten eines bestimmten Dropdown-Men�s
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

    // Setzt den Zustand aller Kinder eines Objekts (optional f�r Seiten)
    public void SetChildrenState(GameObject parentObject, Boolean activate)
    {
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.SetActive(activate);
        }
    }

    // Methode zum Schlie�en eines spezifischen Dropdown-Men�s
    public void CloseDropdownMenu(GameObject dropdownMenu)
    {
        if (dropdownMenu != null && dropdownMenu.activeSelf)
        {
            dropdownMenu.SetActive(false); // Dropdown deaktivieren
            Debug.Log($"Dropdown {dropdownMenu.name} geschlossen.");
        }
        else
        {
            Debug.LogWarning("Dropdown Menu nicht zu schlie�en (entweder null oder bereits geschlossen).");
        }
    }

}
