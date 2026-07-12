using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // 싱글톤 패턴 구현

    [Header("Crosshair")]
    [SerializeField] private Image crosshairImage;
    [SerializeField] private CamcorderUI camcorderUI; 
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color interactColor = Color.grey;
    public CamcorderUI CamcorderUI => camcorderUI; // 캠코더 UI에 대한 public getter

    [Header("Interact Text")]
    [SerializeField] private TMP_Text interactText;

    private void Awake() // 싱글톤 패턴 구현
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void HideInteractText() //   상호작용 가능한 오브젝트를 바라보고 있지 않을 때 상호작용 텍스트 숨김
    {
        interactText.gameObject.SetActive(false);   
    }

}