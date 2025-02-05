using UnityEngine;
using UnityEngine.UI;

public class ScrollToAnchor : MonoBehaviour
{
    public ScrollRect scrollRect;  // Das ScrollRect-Objekt
    public RectTransform targetAnchor;  // Der Ankerpunkt, zu dem gescrollt werden soll

    void Start()
    {
        ScrollToTarget();
    }

    public void ScrollToTarget()
    {
        if (scrollRect != null && targetAnchor != null)
        {
            Canvas.ForceUpdateCanvases();  // Stellt sicher, dass das Layout berechnet wurde
            
            // Den Ankerpunkt in den Scrollbereich bringen
            scrollRect.content.anchoredPosition =
                (Vector2)scrollRect.transform.InverseTransformPoint(scrollRect.content.position) -
                (Vector2)scrollRect.transform.InverseTransformPoint(targetAnchor.position);
        }
    }
}
