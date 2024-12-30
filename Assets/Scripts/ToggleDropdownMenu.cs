using UnityEngine;

public class ToggleDropdownMenu : MonoBehaviour
{
    public GameObject dropdownMenu; // Verknüpfe das Dropdown-Panel hier

    public void ToggleMenu()
    {
        if (dropdownMenu != null)
        {
            bool isActive = dropdownMenu.activeSelf;
            dropdownMenu.SetActive(!isActive); // Aktivieren/Deaktivieren des Dropdowns
        }
    }
}
