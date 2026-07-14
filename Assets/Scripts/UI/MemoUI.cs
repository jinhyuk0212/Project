using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoUI : MonoBehaviour
{
    [Header("Memo UI")]
    [SerializeField] private GameObject memoPanel; // 메모 UI 패널
    [SerializeField] private TMP_Text titleText; // 메모 제목 텍스트
    [SerializeField] private TMP_Text contentText; // 메모 내용 텍스트
    [SerializeField] private Image memoImage; // 메모 이미지

    public bool IsOpen { get; private set; } // 메모 UI가 열려 있는지 여부를 나타내는 public getter
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // 메모 UI가 열려 있을 때 ESC 키를 누르면 메모 UI를 닫음
        {
            CloseMemo();
        }
    }

    public void OpenMemo(MemoData memoData) // 메모 데이터를 받아 메모 UI를 열고 내용을 표시
    {
        if (memoData == null)
            return;

        IsOpen = true;
        memoPanel.SetActive(true);

        titleText.text = memoData.Title;
        contentText.text = memoData.Content;

        if (memoData.MemoImage != null) // 메모 이미지가 존재하면 이미지 표시, 없으면 이미지 비활성화
        {
            memoImage.gameObject.SetActive(true);
            memoImage.sprite = memoData.MemoImage;
        }
        else // 메모 이미지가 없으면 이미지 비활성화
        {
            memoImage.gameObject.SetActive(false);
        }

        Time.timeScale = 0f; // 게임 시간을 일시정지하여 플레이어가 메모 UI를 볼 수 있도록 함
    }

    public void CloseMemo() // 메모 UI를 닫고 게임을 다시 시작
    {
        IsOpen = false;
        memoPanel.SetActive(false);

        Time.timeScale = 1f; // 게임 시간을 다시 시작하여 플레이어가 게임을 진행할 수 있도록 함
    }
}