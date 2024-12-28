using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject[] screens; // Array für deine Screenshots
    private int currentIndex = 0;

    public void ShowNextScreen()
    {
        Debug.Log("Next Button Clicked");
        screens[currentIndex].SetActive(false); // Aktuellen Screen deaktivieren
        currentIndex = (currentIndex + 1) % screens.Length; // Zum nächsten Screen wechseln
        screens[currentIndex].SetActive(true); // Nächsten Screen aktivieren
    }

    public void ShowPreviousScreen()
    {
        Debug.Log("Back Button Clicked");
        screens[currentIndex].SetActive(false); // Aktuellen Screen deaktivieren
        currentIndex = (currentIndex - 1 + screens.Length) % screens.Length; // Zum vorherigen Screen wechseln
        screens[currentIndex].SetActive(true); // Vorherigen Screen aktivieren
    }

}
