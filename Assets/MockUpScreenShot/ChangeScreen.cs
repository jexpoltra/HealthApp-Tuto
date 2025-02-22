using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject[] screens; // Array f�r deine Screenshots
    private int currentIndex = 0;

    public void ShowNextScreen()
    {
        Debug.Log("Next Button Clicked");
        screens[currentIndex].SetActive(false); // Aktuellen Screen deaktivieren
        currentIndex = (currentIndex + 1) % screens.Length; // Zum n�chsten Screen wechseln
        screens[currentIndex].SetActive(true); // N�chsten Screen aktivieren
    }

    public void ShowPreviousScreen()
    {
        Debug.Log("Back Button Clicked");
        screens[currentIndex].SetActive(false); // Aktuellen Screen deaktivieren
        currentIndex = (currentIndex - 1 + screens.Length) % screens.Length; // Zum vorherigen Screen wechseln
        screens[currentIndex].SetActive(true); // Vorherigen Screen aktivieren
    }

}
