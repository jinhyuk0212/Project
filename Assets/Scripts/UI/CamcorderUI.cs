using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CamcorderUI : MonoBehaviour
{
    [Header("Battery")]
    [SerializeField] private Image batteryImage; 
    [SerializeField] private TMP_Text batteryPercentText;
    [SerializeField] private Sprite[] batterySprites;
    // 순서: 0%, 25%, 50%, 75%, 100%

    [Header("Recording")]
    [SerializeField] private TMP_Text recordTimeText;

    [Header("Night Vision")]
    [SerializeField] private Image nvImage;

    private float recordTime;
    private bool isRecording;

    private void Update() // 매 프레임마다 기록 시간 업데이트
    {
        if (!isRecording)
            return;

        recordTime += Time.deltaTime;
        UpdateRecordTime();
    }

    public void ShowCamcorderUI(bool value) // 캠코더 UI 활성화/비활성화
    {
        gameObject.SetActive(value);
        SetBattery(100f); // 캠코더 UI가 활성화될 때 배터리 상태를 초기화
    }

    public void SetBattery(float battery)
    {
        battery = Mathf.Clamp(battery, 0f, 100f);

        batteryPercentText.text = $"{Mathf.RoundToInt(battery)}%";

        if (battery <= 10)
            batteryImage.sprite = batterySprites[0];
        else if (battery <= 25)
            batteryImage.sprite = batterySprites[1];
        else if (battery <= 50)
            batteryImage.sprite = batterySprites[2];
        else if (battery <= 75)
            batteryImage.sprite = batterySprites[3];
        else
            batteryImage.sprite = batterySprites[4];
    }

    public void SetRecording(bool value)
    {
        isRecording = value;

        recordTimeText.gameObject.SetActive(value);

        if (value)
        {
            recordTime = 0f;
            UpdateRecordTime();
        }
    }

    public void SetNightVision(bool value) // 나이트비전 UI 활성화/비활성화
    {
        nvImage.enabled = value;
    }
    private void UpdateRecordTime() // 기록 시간 업데이트
    {
        int totalSeconds = Mathf.FloorToInt(recordTime);
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        recordTimeText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }
}