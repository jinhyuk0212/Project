using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Crosshair")]
    [SerializeField] private Image crosshairImage;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color interactColor = Color.green;

    [Header("Interact Text")]
    [SerializeField] private TMP_Text interactText;

    public void SetCrosshairNormal()
    {
        crosshairImage.color = normalColor;
    }

    public void SetCrosshairInteract()
    {
        crosshairImage.color = interactColor;
    }

    public void ShowInteractText(string text)
    {
        interactText.text = text;
        interactText.gameObject.SetActive(true);
    }

    public void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }
}