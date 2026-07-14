using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    [Header("Crosshair")]
    [SerializeField] private Image crosshairImage; // 크로스헤어 이미지
    [SerializeField] private Color normalColor = Color.white; // 상호작용 가능한 오브젝트를 바라보고 있지 않을 때 크로스헤어 색상
    [SerializeField] private Color interactColor = Color.grey; // 상호작용 가능한 오브젝트를 바라보고 있을 때 크로스헤어 색상

    [Header("Interact Text")]
    [SerializeField] private TMP_Text interactText; // 상호작용 텍스트

    public void SetCrosshairNormal() // 상호작용 가능한 오브젝트를 바라보고 있지 않을 때 크로스헤어 원래대로 변경
    {
        crosshairImage.color = normalColor;
    }

    public void SetCrosshairInteract() // 상호작용 가능한 오브젝트를 바라보고 있을 때 크로스헤어 변경
    {
        crosshairImage.color = interactColor;
    }

    public void ShowInteractText(string text) // 상호작용 가능한 오브젝트를 바라보고 있을 때 상호작용 텍스트 표시
    {
        interactText.text = text;
        interactText.gameObject.SetActive(true);
    }

    public void HideInteractText() // 상호작용 가능한 오브젝트를 바라보고 있지 않을 때 상호작용 텍스트 숨김
    {
        interactText.gameObject.SetActive(false);
    }
}