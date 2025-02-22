using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Dein Dropdown
    public Sprite[] sprites; // Deine Sprites
    public Image targetImage; // Das UI-Image, wo das Sprite angezeigt werden soll

    public void HandleDropdownChange(int value)
    {
        // Pr�fe, ob der Wert innerhalb der Array-Grenzen liegt
        if (value >= 0 && value < sprites.Length)
        {
            targetImage.sprite = sprites[value]; // �ndere das Sprite im UI-Image
        }
        else
        {
            Debug.LogWarning("Ung�ltiger Index: " + value);
        }
    }
}
