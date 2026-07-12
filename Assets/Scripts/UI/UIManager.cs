using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // 싱글톤 패턴 구현

    [SerializeField] private InteractUI interactUI;
    [SerializeField] private CamcorderUI camcorderUI; 
    public CamcorderUI CamcorderUI => camcorderUI; // 캠코더 UI에 대한 public getter
    public InteractUI InteractUI => interactUI; // 상호작용 UI에 대한 public getter

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

}